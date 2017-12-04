using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using Chat.Core.Domain.LogManagement;
namespace Chat.Core.Mapping.LogManagement
{
    public class SystemLogMap : BaseEntityMap<SystemLog, int>
    {
        public override void Configure(EntityTypeBuilder<SystemLog> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.Value).HasColumnName("Value");
            builder.ToTable("SystemLog");
        }
    }
}
