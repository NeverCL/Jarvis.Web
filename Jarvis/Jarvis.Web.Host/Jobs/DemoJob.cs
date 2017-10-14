using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Application.Joke;
using Jarvis.Core;
using Jarvis.Core.Company;
using Jarvis.Web.Host.Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Jarvis.Web.Host.Jobs
{
    public class DemoJob : IJob
    {
        private readonly ServiceProvider _serviceProvider;
        public DemoJob()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<CompanyFactory>()
                .AddDbContext<JarvisDbContext>(options =>
                {
                    options.UseMySql("Server=dev.neverc.cn;database=TestDb;uid=root;pwd=123123;");
                })
                .BuildServiceProvider();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("hello");
            await _serviceProvider.GetService<CompanyFactory>().ActiveCompanyListUrl(null);
        }
    }
}
