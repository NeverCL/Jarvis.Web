using System;
using System.Threading.Tasks;
using Jarvis.Core.Joke;
using Microsoft.Extensions.Logging;
using Module;

namespace Jarvis.Web.Host.Jobs
{
    public class JokeHandle : ITaskHandle
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
                    //await _jokeFactory.SyncHistory(i++, _startDate);
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
