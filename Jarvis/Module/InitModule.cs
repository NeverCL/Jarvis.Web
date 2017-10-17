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
        /// <param name="services"></param>
        public virtual void Initialize(IServiceCollection services)
        {
            
        }

        /// <summary>
        /// 创建IServiceProvider后 执行
        /// </summary>
        /// <param name="provider"></param>
        public virtual void PostInitialize(IServiceProvider provider)
        {
            
        }

        public virtual Task InitializeAsync(IServiceCollection services)
        {
            Initialize(services);
            return Task.CompletedTask;
        }

        public virtual Task PostInitializeAsync(IServiceProvider provider)
        {
            PostInitialize(provider);
            return Task.CompletedTask;
        }
    }
}
