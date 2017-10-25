using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Module.EntityFrameworkCore;

namespace Module
{
    public class StartModule : InitModule
    {
        public override void Initialize(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient(typeof(IDbContextProvider<>), typeof(DbContextProvider<>));
            base.Initialize(serviceCollection);
        }

        public override void PostInitialize(IServiceProvider provider)
        {
            foreach (var taskHandle in provider.GetServices<ITaskHandle>())
            {
                taskHandle.Handle();
            }
        }
    }
}
