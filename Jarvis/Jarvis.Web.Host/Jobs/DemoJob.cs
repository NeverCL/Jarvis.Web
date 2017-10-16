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
using Microsoft.Extensions.Logging;
using Quartz;

namespace Jarvis.Web.Host.Jobs
{
    public class DemoJob : IJob
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
