using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Application;
using Jarvis.Application.Joke;
using Jarvis.Core;
using Jarvis.Core.Company;
using Jarvis.Core.HttpData;
using Jarvis.Core.Joke;
using Jarvis.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module;
using Module.Domain.Uow;
using Module.EntityFrameworkCore;
using Module.EntityFrameworkCore.Uow;
using Xunit;

namespace Jarvis.Tests.Module
{
    public class JarvisTestBase
    {
        private ServiceProvider _serviceProvider;

        public JarvisTestBase()
        {
            Init().Wait();
        }

        [Fact]
        private async Task Init()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContextPool<JarvisDbContext>(options =>
            {
                options.UseMySql("Server=dev.neverc.cn;database=TestDb;uid=root;pwd=123123;");
            });
            //serviceCollection.AddTransient(typeof(IDbContextProvider<>), typeof(DbContextProvider<>));
            //_serviceProvider = serviceCollection.BuildServiceProvider();
            //var db = _serviceProvider.GetService<DbContext>();
            //db = _serviceProvider.GetService<JarvisDbContext>();
            //var dbProvider = _serviceProvider.GetService<IDbContextProvider<JarvisDbContext>>();
            //serviceCollection.AddTransient(typeof(DbContext), typeof(JarvisDbContext));
            _serviceProvider = await serviceCollection.AddModuleAsync();
            var dataFactory = _serviceProvider.GetService<HttpDataFactory>();
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
