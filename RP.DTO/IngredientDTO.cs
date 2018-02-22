using System;

namespace RP.DTO
{
    public class IngredientDTO
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public Guid RecipeId { get; set; }
    }
}