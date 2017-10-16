using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Core;
using Jarvis.Core.Company;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jarvis.Web.Host.Jobs
{
    public class CompanyJob
    {
        public async Task Loop()
        {
            var _serviceProvider = new ServiceCollection()
                .AddTransient<CompanyFactory>()
                .AddDbContext<JarvisDbContext>(options =>
                {
                    options.UseMySql("Server=dev.neverc.cn;database=TestDb;uid=root;pwd=123123;");
                })
                .BuildServiceProvider();

            long i = 2316538306;
            while (true)
            {
                var url = "https://www.tianyancha.com/company/" + (i++);
                await _serviceProvider.GetService<CompanyFactory>().CreateCompany(url);
                await Task.Delay(100);
            }
        }
    }
}
