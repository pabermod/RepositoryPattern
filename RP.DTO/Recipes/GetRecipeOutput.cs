using RP.DTO.Ingredients;
using System;
using System.Collections.Generic;

namespace RP.DTO.Recipes
{
    public class GetRecipeOutput : RecipeDTO
    {
        public Guid Id { get; set; }
        public virtual List<IngredientDTO> Ingredients { get; set; }
    }
}