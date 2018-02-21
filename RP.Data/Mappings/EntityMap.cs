using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RP.Data.Mappings
{
    public abstract class EntityMap<TEntity> where TEntity : BaseEntity
    {
        public EntityMap(EntityTypeBuilder<TEntity> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.AddedDate);
            entityBuilder.Property(t => t.ModifiedDate);
        }
    }
}