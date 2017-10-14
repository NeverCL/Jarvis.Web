using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Application.Joke;
using Jarvis.Application.Joke.Dto;
using Jarvis.Application.Module;
using Jarvis.Core;
using Jarvis.Core.Joke;
using Microsoft.EntityFrameworkCore;

namespace Jarvis.Application
{
    public class JokeApplication:BaseApplication, IJokeApplication
    {
        private readonly JarvisDbContext _dbContext;

        public JokeApplication(JarvisDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IList<JokeDto> GetJokes(GetJokesInput input)
        {
            var jokes = _dbContext.Jokes.OrderByDescending(x => x.CreateTime).PageBy(input);

            return jokes.MapTo<IList<JokeDto>>();
        }

        public async Task CreateJoke(DateTime date, int pageIndex)
        {
            var jokes = await new JokeFactory().Build(date, pageIndex);
            jokes = jokes.Where(x => _dbContext.Jokes.AsNoTracking().Any(y => y.ImageUrl == x.ImageUrl)).ToList();
            _dbContext.Jokes.AddRange(jokes.ToArray());
            _dbContext.SaveChanges();
        }
    }
}
