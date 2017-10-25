using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Module;
using Module.Domain.Repository;

namespace Jarvis.EntityFrameworkCore
{
    public class EfCoreModule : InitModule
    {
        public override Task InitializeAsync(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IRepository<,>), typeof(JarvisRepository<,>));
            return base.InitializeAsync(serviceCollection);
        }
    }
}
