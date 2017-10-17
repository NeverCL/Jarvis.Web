using System.Threading.Tasks;
using Module.Dependency;
using Quartz;

namespace Jarvis.Web.Host.Jobs
{
    public class DemoJob : IJob, ITransientDependency
    {
        //private readonly ILogger _logger;

        //public DemoJob(ILogger<DemoJob> logger)
        //{
        //    this._logger = logger;
        //}

        public DemoJob()
        {

        }

        public async Task Execute(IJobExecutionContext context)
        {
            //_logger.LogWarning("hello");
        }
    }
}
