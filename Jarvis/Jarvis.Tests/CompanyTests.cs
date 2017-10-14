using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jarvis.Application.Joke;
using Jarvis.Application.Joke.Dto;
using Jarvis.Core.Company;
using Jarvis.Tests.Module;
using Shouldly;
using Xunit;

namespace Jarvis.Tests
{
    public class CompanyTests : JarvisTestBase
    {
        private readonly CompanyFactory _companyFactory;
        public CompanyTests()
        {
            _companyFactory = Resolve<CompanyFactory>();
        }

        [Fact]
        public async Task Should_Not_ThrowException_CreateCompany()
        {
            var id = "172870250";
            await _companyFactory.CreateCompany(id);
        }

        [Fact]
        public async Task Should_Not_ThrowException_CreateCompanys()
        {
            var url = "https://www.tianyancha.com/search?key=%E5%8C%BB%E7%96%97&checkFrom=searchBox";
            await _companyFactory.CreateCompanys(url);
        }

    }
}
