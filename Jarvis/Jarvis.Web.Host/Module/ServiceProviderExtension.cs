using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Jarvis.Core.Company;
using Jarvis.Core.Joke;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Jarvis.Web.Host.Module
{
    public static class ServiceProviderService
    {
        private static IServiceProvider _serviceProvider;

        public static event Action<IServiceProvider> Prepare;

        static ServiceProviderService()
        {
            Prepare += serviceProvider =>
            {
                var handles = serviceProvider.GetServices<IAlwaysHandle>();
                foreach (var handle in handles)
                {
                    Task.Run(() => handle.Handle());
                }
            };
        }

        public static void Init(IServiceCollection services)
        {
            services
                .AddTransient<CompanyFactory>()
                .AddTransient<JokeFactory>();

            AddServiceByInterface(services, typeof(IAlwaysHandle));

            AddServiceByInterface(services, typeof(IJob), ServiceLifetime.Transient, true);

            _serviceProvider = services.BuildServiceProvider();

            Prepare?.Invoke(_serviceProvider);

        }

        private static void AddServiceByInterface(IServiceCollection services, Type interfaceType, ServiceLifetime serviceLifetime = ServiceLifetime.Singleton, bool selfInterface = false)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                if (type.GetInterfaces().Contains(interfaceType))
                {
                    services.Add(new ServiceDescriptor(selfInterface ? type : interfaceType, type, serviceLifetime));
                }
            }
        }


        public static object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public static T GetService<T>() where T : class
        {
            return _serviceProvider.GetService(typeof(T)) as T;
        }

    }
}
