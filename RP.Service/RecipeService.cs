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
        public RecipeService(IRepositoryFactory repositoryFactory, IMapper mapper)
            : base(repositoryFactory, mapper)
        {
        }

        public async Task<IEnumerable<GetAllRecipesOutput>> GetAll()
        {
            return await repository.Get().AsNoTracking().ProjectTo<GetAllRecipesOutput>().ToListAsync();
        }

        public async Task<GetRecipeOutput> GetRecipe(Guid id)
        {
            return await repository.Get().ProjectTo<GetRecipeOutput>().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<PostRecipeOutput> Create(PostRecipeInput recipe)
        {
            if (recipe == null)
            {
                throw new ArgumentNullException("recipe");
            }
            var recipeEntity = mapper.Map<Recipe>(recipe);
            var createdEntity = await repository.Add(recipeEntity);
            return mapper.Map<PostRecipeOutput>(createdEntity);
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