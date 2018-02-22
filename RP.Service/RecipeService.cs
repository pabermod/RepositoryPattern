using RP.Data;
using RP.Repo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RP.Service
{
    public class RecipeService : EntityService<Recipe>, IRecipeService
    {
        public RecipeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Recipe> GetAll()
        {
            return repository.Get();
        }

        public Task<List<Recipe>> GetAllAsync()
        {
            return repository.GetAsync();
        }

        public Recipe GetRecipe(Guid id)
        {
            return repository.GetEntity(id, r => r.Ingredients);
        }

        public Task<Recipe> GetRecipeAsync(Guid id)
        {
            return repository.GetEntityAsync(id, r => r.Ingredients);
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