using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jarvis.Web.Host.Module
{
    public interface IAlwaysHandle
    {
        Task Handle();
    }
}
