using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RP.Data.Mappings
{
    public class RecipeMap : EntityMap<Recipe>
    {
        public RecipeMap(EntityTypeBuilder<Recipe> entityBuilder)
            : base(entityBuilder)
        {
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Description).IsRequired();
            entityBuilder.Property(t => t.ImagePath).IsRequired();
        }
    }
}