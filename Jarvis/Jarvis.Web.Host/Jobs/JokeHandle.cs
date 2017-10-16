using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Core.Joke;
using Jarvis.Web.Host.Module;
using Microsoft.Extensions.Logging;

namespace Jarvis.Web.Host.Jobs
{
    public class JokeHandle : IAlwaysHandle
    {
        private readonly JokeFactory _jokeFactory;
        private DateTime _startDate = DateTime.Parse("2016/1/25 14:32:00");
        private readonly ILogger _logger;

        public JokeHandle(JokeFactory jokeFactory, ILogger<JokeHandle> logger)
        {
            this._jokeFactory = jokeFactory;
            this._logger = logger;
            _logger.LogWarning("Hello");
        }

        public async Task Handle()
        {
            var i = 0;
            while (true)
            {
                try
                {
                    await _jokeFactory.SyncHistory(i++, _startDate);
                    await Task.Delay(100);
                }
                catch (Exception)
                {
                    _startDate = _startDate.AddDays(-7);
                    _logger.LogWarning("重新赋值日期" + _startDate);
                    await Handle();
                }
            }
        }
    }
}
