using RP.DTO.Ingredients;
using System;
using System.Collections.Generic;

namespace RP.DTO.Recipes
{
    public class PostRecipeOutput : RecipeDTO
    {
        public Guid Id { get; set; }

        public ICollection<IngredientDTO> Ingredients { get; set; }

        public IList<string> Directions { get; set; }
    }
}