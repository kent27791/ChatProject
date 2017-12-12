using Chat.Core.Domain.SecurityManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Mapping.SecurityManagement
{
    public class MemberMap : BaseEntityMap<Member, int>
    {
        public override void Configure(EntityTypeBuilder<Member> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.Name).HasMaxLength(50).HasColumnName("Name");
            builder.ToTable("Member");
        }
    }
}
