using Microsoft.AspNetCore.Identity;

namespace Chat.Core.Domain.SecurityManagement
{
    public class UserRole : IdentityUserRole<long>
    {
        public override long UserId { get; set; }
        public override long RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
