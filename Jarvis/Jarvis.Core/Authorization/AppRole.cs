using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Jarvis.Core
{
    public class AppRole : IdentityRole
    {
        public string DisplayName { get; set; }
    }
}
