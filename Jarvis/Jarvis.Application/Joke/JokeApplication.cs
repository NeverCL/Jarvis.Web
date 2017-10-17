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
using Module.Dependency;

namespace Jarvis.Application
{
    public class JokeApplication : BaseApplication, IJokeApplication, ITransientDependency
    {
        //private readonly JarvisDbContext _dbContext;

        //public JokeApplication(JarvisDbContext dbContext)
        //{
        //    this._dbContext = dbContext;
        //}

        //public IList<JokeDto> GetJokes(GetJokesInput input)
        //{
        //    var jokes = _dbContext.Jokes.OrderByDescending(x => x.CreateTime).PageBy(input);

        //    return jokes.MapTo<IList<JokeDto>>();
        //}

    }
}
