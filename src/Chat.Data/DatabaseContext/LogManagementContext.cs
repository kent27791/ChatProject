using Chat.Core.Data;
using Chat.Core.Domain.LogManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chat.Data.DatabaseContext
{
    public class LogManagementContext : DbContext, IDatabaseContext<LogManagementContext>
    {
        public LogManagementContext(DbContextOptions<LogManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemLog>().ToTable("SystemLog");
            base.OnModelCreating(modelBuilder);
        }

        public void Commit()
        {
            SaveChanges();
        }
    }
}
