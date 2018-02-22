using System.Collections.Generic;

namespace RP.DTO.Recipes
{
    public class GetRecipeOutput : RecipeDTO
    {
        public virtual List<IngredientDTO> Ingredients { get; set; }
    }
}