using System;
using System.Threading.Tasks;
using Jarvis.Web.Host.Jobs;
using Module;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Spi;

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
                var obj = _serviceProvider.GetService(jobType) as IJob;
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
