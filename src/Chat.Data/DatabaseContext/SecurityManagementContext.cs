using Chat.Core.Data;
using Chat.Core.Domain.SecurityManagement;
using Chat.Core.Mapping.SecurityManagement;
using Microsoft.EntityFrameworkCore;

namespace Chat.Data.DatabaseContext
{
    public class SecurityManagementContext : DbContext, IDatabaseContext<SecurityManagementContext>
    {
        public SecurityManagementContext(DbContextOptions<SecurityManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new GroupMemberMap());
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
