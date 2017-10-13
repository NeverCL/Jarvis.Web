using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quartz;

namespace Jarvis.Web.Host.Jobs
{
    /// <summary>
    /// 每分钟拉取最新Joke
    /// </summary>
    public class JokeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.CompletedTask;
        }
    }
}
