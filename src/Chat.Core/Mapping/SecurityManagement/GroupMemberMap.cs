using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Chat.Core.Domain.SecurityManagement;
namespace Chat.Core.Mapping.SecurityManagement
{
    public class GroupMemberMap : BaseEntityMap<GroupMember, int>
    {
        public override void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.GroupName).HasMaxLength(255).HasColumnName("GroupName");
            builder.ToTable("GroupMember");
        }
    }
}
