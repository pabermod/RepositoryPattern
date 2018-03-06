using System;

namespace RP.Data
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }

        public string Amount { get; set; }

        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}