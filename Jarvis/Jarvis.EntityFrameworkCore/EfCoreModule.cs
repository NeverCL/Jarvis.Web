using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Module;
using Module.Domain.Repository;

namespace Jarvis.EntityFrameworkCore
{
    public class EfCoreModule : InitModule
    {
        public override void Initialize(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<,>), typeof(JarvisRepository<,>));
            base.Initialize(services);
        }
    }
}
