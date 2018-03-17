using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RP.Data.Mappings
{
    public class IngredientMap : EntityMap<Ingredient>
    {
        public IngredientMap(EntityTypeBuilder<Ingredient> entityBuilder)
            : base(entityBuilder)
        {
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Quantity).IsRequired();
            entityBuilder
                .HasOne(e => e.Recipe)
                .WithMany(e => e.Ingredients)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}