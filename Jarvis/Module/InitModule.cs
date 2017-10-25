using System;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Module
{
    /// <summary>
    /// 在创建IServiceCollection时 和 创建IServiceProvider后 启动Module
    /// </summary>
    public abstract class InitModule
    {
        /// <summary>
        /// 创建IServiceCollection时 执行
        /// </summary>
        /// <param name="serviceCollection"></param>
        public virtual void Initialize(IServiceCollection serviceCollection)
        {
            
        }

        /// <summary>
        /// 创建IServiceProvider后 执行
        /// </summary>
        /// <param name="serviceProvider"></param>
        public virtual void PostInitialize(IServiceProvider serviceProvider)
        {
            
        }

        public virtual Task InitializeAsync(IServiceCollection serviceCollection)
        {
            Initialize(serviceCollection);
            return Task.CompletedTask;
        }

        public virtual Task PostInitializeAsync(IServiceProvider serviceProvider)
        {
            PostInitialize(serviceProvider);
            return Task.CompletedTask;
        }
    }
}
