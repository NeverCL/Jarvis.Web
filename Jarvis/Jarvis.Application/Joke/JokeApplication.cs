using System.Collections.Generic;
using System.Linq;
using Jarvis.Application.Joke;
using Jarvis.Application.Joke.Dto;
using Jarvis.Application.Module;
using Module.Dependency;
using Jarvis.EntityFrameworkCore;

namespace Jarvis.Application
{
    public class JokeApplication : BaseApplication, IJokeApplication, ITransientDependency
    {
        //private readonly JarvisDbContext _dbContext;

        //public JokeApplication(JarvisDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}
        //private JarvisRepositoryBase<Core.Joke.Joke> jokeRepository;

        //public IList<JokeDto> GetJokes(GetJokesInput input)
        //{
        //    var jokes = _dbContext.Jokes.OrderByDescending(x => x.CreateTime).PageBy(input);

        //    return jokes.MapTo<IList<JokeDto>>();
        //}

        private readonly JarvisRepository<Core.Joke.Joke> _jokeRepository;

        public JokeApplication(JarvisRepository<Core.Joke.Joke> jokeRepository)
        {
            this._jokeRepository = jokeRepository;
        }

        public IList<JokeDto> GetJokes(GetJokesInput input)
        {
            var jokes = _jokeRepository.GetAll().OrderByDescending(x => x.CreateTime).PageBy(input);

            return jokes.MapTo<IList<JokeDto>>();
        }
    }
}
