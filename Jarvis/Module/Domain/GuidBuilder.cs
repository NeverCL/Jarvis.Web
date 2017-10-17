using System;

namespace Module.Domain
{
    public class GuidBuilder
    {
        public static string Build()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
