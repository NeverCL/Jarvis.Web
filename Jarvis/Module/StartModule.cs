using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Module
{
    public class StartModule : InitModule
    {
        public override void PostInitialize(IServiceProvider provider)
        {
            foreach (var taskHandle in provider.GetServices<ITaskHandle>())
            {
                taskHandle.Handle();
            }
        }
    }
}
