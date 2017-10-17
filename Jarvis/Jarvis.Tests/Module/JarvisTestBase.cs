using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.Application;
using Jarvis.Application.Joke;
using Jarvis.Core;
using Jarvis.Core.Company;
using Jarvis.Core.Joke;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jarvis.Tests.Module
{
    public class JarvisTestBase
    {
        private readonly ServiceProvider _serviceProvider;

        public JarvisTestBase()
        {
           
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
