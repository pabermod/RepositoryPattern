using RP.DTO.Ingredients;
using System.Collections.Generic;

namespace RP.DTO.Recipes
{
    public class PostRecipeInput : RecipeDTO
    {
        /// <summary>
        /// Ingredients of the recipe
        /// </summary>
        public IEnumerable<IngredientDTO> Ingredients { get; set; }
    }
}