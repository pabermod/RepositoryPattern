using RP.DTO.Ingredients;
using System.Collections.Generic;

namespace RP.DTO.Recipes
{
    public class PostRecipeInput : RecipeDTO
    {
        public IEnumerable<IngredientDTO> Ingredients { get; set; }
        public IList<string> Directions { get; set; }
    }
}