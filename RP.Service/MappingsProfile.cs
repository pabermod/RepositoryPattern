using AutoMapper;
using RP.Data;
using RP.DTO.Ingredients;
using RP.DTO.Recipes;

namespace RP.Service
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<PostRecipeInput, Recipe>();
            CreateMap<Recipe, PostRecipeOutput>();
            CreateMap<IngredientDTO, Ingredient>();
        }
    }
}