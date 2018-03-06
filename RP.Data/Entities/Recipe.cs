using System.Collections.Generic;

namespace RP.Data
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}