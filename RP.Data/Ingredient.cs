using System;

namespace RP.Data
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public Guid RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}