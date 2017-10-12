using System;
using Microsoft.AspNetCore.Identity;

namespace Jarvis.Core
{
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string DisplayName { get; set; }
    }
}
