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
            CreateMap<PostRecipeInput, Recipe>(MemberList.Source);
            CreateMap<IngredientDTO, Ingredient>(MemberList.Source).ReverseMap();
            CreateMap<Recipe, PostRecipeOutput>(MemberList.Destination);
            CreateMap<Recipe, GetAllRecipesOutput>(MemberList.Destination);
            CreateMap<Recipe, GetRecipeOutput>(MemberList.Destination);
        }
    }
}