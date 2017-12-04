using Chat.Core.Data;
using Chat.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chat.Data.DatabaseContext
{
    public class ChatManagementContext : DbContext, IDatabaseContext<ChatManagementContext>
    {
        public ChatManagementContext(DbContextOptions<ChatManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SystemLog>().ToTable("SystemLog");
            base.OnModelCreating(modelBuilder);
        }


        public void Commit()
        {
            SaveChanges();
        }
    }
}
