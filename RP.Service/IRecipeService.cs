using RP.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAll();

        Task<List<Recipe>> GetAllAsync();

        Guid Insert(Recipe recipe);

        Recipe GetRecipe(Guid id);

        Task<Recipe> GetRecipeAsync(Guid id);

        Guid Update(Recipe recipe);
    }
}