﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Application.Joke;
using Jarvis.Core;
using Jarvis.Core.Company;
using Jarvis.Web.Host.Module;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Jarvis.Web.Host.Jobs
{
    public class DemoJob : IJob
    {
        public DemoJob()
        {

        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("hello");
        }
    }
}
