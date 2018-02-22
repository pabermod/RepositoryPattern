using AutoMapper;
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
        public RecipeService(IUnitOfWork unitOfWork, IMapper iMapper) : base(unitOfWork, iMapper)
        {
        }

        public IEnumerable<GetAllRecipesOutput> GetAll()
        {
            return iMapper.Map<IEnumerable<GetAllRecipesOutput>>(repository.Get());
        }

        public async Task<IEnumerable<GetAllRecipesOutput>> GetAllAsync()
        {
            var recipes = await repository.GetAsync();
            return iMapper.Map<IEnumerable<GetAllRecipesOutput>>(recipes);
        }

        public GetRecipeOutput GetRecipe(Guid id)
        {
            var recipeEntity = repository.GetEntity(id, r => r.Ingredients);
            return iMapper.Map<GetRecipeOutput>(recipeEntity);
        }

        public async Task<GetRecipeOutput> GetRecipeAsync(Guid id)
        {
            var recipeEntity = await repository.GetEntityAsync(id, r => r.Ingredients);
            return iMapper.Map<GetRecipeOutput>(recipeEntity);
        }

        public Guid Update(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException("recipe");
            }
            repository.Update(recipe);
            unitOfWork.Commit();
            return recipe.Id;
        }

        public Guid Insert(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException("recipe");
            }
            repository.Add(recipe);
            unitOfWork.Commit();
            return recipe.Id;
        }
    }
}