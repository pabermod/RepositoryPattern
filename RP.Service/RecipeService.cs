using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RP.Data;
using RP.DTO.Recipes;
using RP.Repo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public class RecipeService : EntityService<Recipe>, IRecipeService
    {
        public RecipeService(IRepositoryFactory repositoryFactory, IMapper iMapper) : base(repositoryFactory, iMapper)
        {
        }

        public async Task<IEnumerable<GetAllRecipesOutput>> GetAll()
        {
            var recipes = repository.Get().ProjectTo<GetAllRecipesOutput>();
            return await recipes.ToListAsync();
        }

        public async Task<GetRecipeOutput> GetRecipe(Guid id)
        {
            var recipeEntity = await repository.GetEntity(id, r => r.Ingredients);
            return iMapper.Map<GetRecipeOutput>(recipeEntity);
        }

        public Task<Guid> Create(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException("recipe");
            }
            return repository.Add(recipe);
        }

        public async Task Update(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException("recipe");
            }
            await repository.Update(recipe);
        }

        public async Task Delete(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            await repository.Delete(id);
        }
    }
}