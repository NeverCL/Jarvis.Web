using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Jarvis.Core.Authorization
{
    public class RoleManager : RoleManager<AppRole>
    {
        public RoleManager(IRoleStore<AppRole> store, IEnumerable<IRoleValidator<AppRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<AppRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
