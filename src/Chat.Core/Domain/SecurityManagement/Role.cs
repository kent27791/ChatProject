using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Chat.Core.Domain.SecurityManagement
{
    public class Role : IdentityRole<long>
    {
        public IList<UserRole> Users { get; set; }
    }
}
