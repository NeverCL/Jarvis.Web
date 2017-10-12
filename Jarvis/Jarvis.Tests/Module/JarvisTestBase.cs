﻿using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.Application;
using Jarvis.Application.Joke;
using Jarvis.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jarvis.Tests.Module
{
    public class JarvisTestBase
    {
        private readonly ServiceProvider _serviceProvider;

        public JarvisTestBase()
        {
            _serviceProvider = new ServiceCollection()
                .AddTransient<IJokeApplication, JokeApplication>()
                .AddDbContext<JarvisDbContext>(options =>
                {
                    options.UseMySql("Server=dev.neverc.cn;database=TestDb;uid=root;pwd=123123;port=32772");
                })
                .BuildServiceProvider();
        }

        public T Resolve<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}