using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Application.Joke;
using Jarvis.Application.Joke.Dto;
using Jarvis.Application.Module;
using Jarvis.Core;

namespace Jarvis.Application
{
    public class JokeApplication : IJokeApplication
    {
        private JarvisDbContext _dbContext;
        public JokeApplication(JarvisDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IList<JokeDto> GetJokes(GetJokesInput input)
        {
            var jokes = _dbContext.Jokes.OrderByDescending(x => x.CreateTime).PageBy(input);

            return jokes.MapTo<IList<JokeDto>>();
        }

        public Task CreateJoke(JokeDto input)
        {
            throw new NotImplementedException();
        }
    }
}
