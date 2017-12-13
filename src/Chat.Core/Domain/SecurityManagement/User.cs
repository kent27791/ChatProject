using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Chat.Core.Domain.SecurityManagement
{
    public class User : IdentityUser<long>
    {
        public IList<UserRole> Roles { get; set; }
    }
}
