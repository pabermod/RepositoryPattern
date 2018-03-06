using RP.Data;
using RP.DTO.Recipes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public interface IRecipeService
    {
        Task<IEnumerable<GetAllRecipesOutput>> GetAll();

        Task<GetRecipeOutput> GetRecipe(Guid id);

        Task<PostRecipeOutput> Create(PostRecipeInput recipe);

        Task Update(Recipe recipe);

        Task Delete(Guid id);
    }
}