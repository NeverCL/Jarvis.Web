using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Jarvis.Web.Host.Jobs;
using Jarvis.Web.Host.Module;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Simpl;
using Quartz.Spi;

namespace Jarvis.Web.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceProviderService.Prepare += async provider =>
            {
                await InitQuartzAsync(provider); // Init Quartz 异步
            };
            BuildWebHost(args).Run();   // Init Web 阻塞方法
        }

        private static async Task InitQuartzAsync(IServiceProvider serviceProvider)
        {
            //NameValueCollection props = new NameValueCollection
            //{
            //    { "quartz.serializer.type", "binary" }
            //};
            //StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            // and start it off
            await scheduler.Start();

            scheduler.JobFactory = new JobFactory(serviceProvider);
            await scheduler.ScheduleJob(new JobDetailImpl("job", typeof(DemoJob)), new CronTriggerImpl("trigger", "trigger", "0/3 * * * * ?"));
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }

    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public JobFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            IJobDetail jobDetail = bundle.JobDetail;
            Type jobType = jobDetail.JobType;

            try
            {
                var obj = ServiceProviderService.GetService(jobType) as IJob;
                return obj;
            }
            catch (Exception ex)
            {
                throw new SchedulerException(string.Format("Problem instantiating class '{0}'", (object)jobDetail.JobType.FullName), ex);
            }
        }

        public void ReturnJob(IJob job)
        {
            IDisposable disposable = job as IDisposable;
            disposable?.Dispose();
        }
    }
}
