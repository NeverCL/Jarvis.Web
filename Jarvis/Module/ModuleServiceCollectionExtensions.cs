using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Module.Dependency;
using System.Linq;
using System.Threading.Tasks;

namespace Module
{
    /// <summary>
    /// Module 框架IoC 入口
    /// </summary>
    public static class ModuleServiceCollectionExtensions
    {
        static List<Type> Types = new List<Type>();
        static List<Assembly> Assemblies = new List<Assembly>();

        static async Task Init()
        {
            await Task.Run(() =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                //var assemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
                foreach (var assembly in assemblies)
                {
                    var types = assembly.GetTypes();
                    foreach (var type in types)
                    {
                        if (type.BaseType == typeof(InitModule))
                        {
                            Assemblies.Add(assembly);
                            Types.AddRange(types);
                            break;
                        }
                    }
                }
            });
        }

        /// <summary>
        /// 1. 加载所有ITransientDependency、ISingletonDependency、IScopedDependency（通用型）
        /// 2. 加载所有InitModule（自定义型）
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static ServiceProvider AddModule(this IServiceCollection services)
        {
            return AddModuleAsync(services).GetAwaiter().GetResult();
        }

        public static async Task<ServiceProvider> AddModuleAsync(this IServiceCollection services)
        {
            await Init();

            // 1. 加载通用型
            foreach (var type in Types)
            {
                if (type.IsClass)
                {
                    var interfaces = type.GetInterfaces();
                    if (interfaces.Contains(typeof(ITransientDependency)))
                    {
                        services.AddTransient(type, type);
                        foreach (var interfaceType in interfaces)
                        {
                            services.AddTransient(interfaceType, type);
                        }
                    }
                    if (interfaces.Contains(typeof(ISingletonDependency)))
                    {
                        services.AddSingleton(type, type);
                        foreach (var interfaceType in interfaces)
                        {
                            services.AddSingleton(interfaceType, type);
                        }
                    }
                    if (interfaces.Contains(typeof(IScopedDependency)))
                    {
                        services.AddScoped(type, type);
                        foreach (var interfaceType in interfaces)
                        {
                            services.AddScoped(interfaceType, type);
                        }
                    }
                }
            }
            // 2. 加载自定义型
            var modules = new List<InitModule>();
            foreach (var type in Types)
            {
                if (type.BaseType == typeof(InitModule))
                    if (Activator.CreateInstance(type) is InitModule module)
                        modules.Add(module);
            }
            foreach (var initModule in modules)
                await initModule.InitializeAsync(services);
            var provider = services.BuildServiceProvider();
            foreach (var initModule in modules)
                await initModule.PostInitializeAsync(provider);
            return provider;
        }

    }
}
