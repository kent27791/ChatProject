using Chat.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chat.Core.Mapping
{
    public class BaseEntityMap<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id).HasName("Id");
            builder.Property(m => m.IsEnable).HasColumnName("IsEnable");
            builder.Property(m => m.CreatedOn).HasColumnName("CreatedOn");
            builder.Property(m => m.UpdatedOn).HasColumnName("UpdatedOn");
        }
    }
}
