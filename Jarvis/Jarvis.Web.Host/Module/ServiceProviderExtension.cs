using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Core.Company;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jarvis.Web.Host.Module
{
    public static class ServiceProviderService
    {
        private static IServiceProvider _serviceProvider;

        public static void Init(IServiceCollection services)
        {
            services.AddTransient<CompanyFactory>();

            _serviceProvider = services.BuildServiceProvider();
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
