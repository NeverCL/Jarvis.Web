using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Core.Joke;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Jarvis.Web.Host.Jobs
{
    /// <inheritdoc />
    /// <summary>
    /// 每分钟拉取最新Joke
    /// </summary>
    public class JokeJob : IJob
    {
        private readonly JokeFactory _jokeFactory;

        public JokeJob(JokeFactory jokeFactory)
        {
            this._jokeFactory = jokeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _jokeFactory.Sync();
        }
    }
}
