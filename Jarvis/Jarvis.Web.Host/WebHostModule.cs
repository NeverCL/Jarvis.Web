using System;
using System.Threading.Tasks;
using Jarvis.Web.Host.Jobs;
using Module;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace Jarvis.Web.Host
{
    public class WebHostModule : InitModule
    {
        public override async Task PostInitializeAsync(IServiceProvider provider)
        {
            var scheduler = await StdSchedulerFactory.GetDefaultScheduler();

            // and start it off
            await scheduler.Start();

            scheduler.JobFactory = new JobFactory(provider);
            await scheduler.ScheduleJob(new JobDetailImpl("job", typeof(DemoJob)), new CronTriggerImpl("trigger", "trigger", "0/3 * * * * ?"));
        }
    }
}
