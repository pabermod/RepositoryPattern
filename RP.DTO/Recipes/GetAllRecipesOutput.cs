using System;

namespace RP.DTO.Recipes
{
    public class GetAllRecipesOutput : RecipeDTO
    {
        /// <summary>
        /// Id of the recipe
        /// </summary>
        public Guid Id { get; set; }
    }
}