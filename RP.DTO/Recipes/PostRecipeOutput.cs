using RP.DTO.Ingredients;
using System;
using System.Collections.Generic;

namespace RP.DTO.Recipes
{
    public class PostRecipeOutput : RecipeDTO
    {
        /// <summary>
        /// Id of the recipe
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ingredients of the recipe
        /// </summary>
        public ICollection<IngredientDTO> Ingredients { get; set; }
    }
}