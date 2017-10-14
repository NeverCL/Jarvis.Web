using System.Collections.Specialized;
using System.Threading.Tasks;
using Jarvis.Web.Host.Jobs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Jarvis.Web.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitQuartz().GetAwaiter().GetResult();  // Init Quartz
            BuildWebHost(args).Run();   // Init Web
        }

        private static async Task InitQuartz()
        {
            //NameValueCollection props = new NameValueCollection
            //{
            //    { "quartz.serializer.type", "binary" }
            //};
            //StdSchedulerFactory factory = new StdSchedulerFactory(props);
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            // and start it off
            await scheduler.Start();

            await scheduler.ScheduleJob(new JobDetailImpl("job", typeof(DemoJob)), new CronTriggerImpl("trigger", "trigger", "0 * * * * ?"));
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
