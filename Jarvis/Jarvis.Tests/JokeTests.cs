using System;
using System.Threading.Tasks;
using Jarvis.Application.Joke;
using Jarvis.Application.Joke.Dto;
using Jarvis.Core.Joke;
using Jarvis.Tests.Module;
using Shouldly;
using Xunit;

namespace Jarvis.Tests
{
    public class JokeTests : JarvisTestBase
    {
        private readonly IJokeApplication _jokeApplication;


        public JokeTests()
        {
            this._jokeApplication = Resolve<IJokeApplication>();
        }

        [Fact]
        public void Should_NotNull_GetJokes()
        {
            var jokes = _jokeApplication.GetJokes(new GetJokesInput());
            jokes.ShouldNotBeNull();
            jokes.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_Not_Throw_Sync()
        {
            //await _jokeFactory.Sync();
        }

        [Fact]
        public async Task Should_Not_Throw_SyncHistory()
        {
            //await _jokeFactory.SyncHistory(23);
        }
    }
}
