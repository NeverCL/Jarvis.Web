using System;
using System.Collections.Generic;
using System.Text;

namespace Jarvis.Core.Module
{
    public class GuidBuilder
    {
        public static string Build()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
