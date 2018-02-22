using RP.Data;
using RP.DTO.Recipes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public interface IRecipeService
    {
        IEnumerable<GetAllRecipesOutput> GetAll();

        Task<IEnumerable<GetAllRecipesOutput>> GetAllAsync();

        Guid Insert(Recipe recipe);

        GetRecipeOutput GetRecipe(Guid id);

        Task<GetRecipeOutput> GetRecipeAsync(Guid id);

        Guid Update(Recipe recipe);
    }
}