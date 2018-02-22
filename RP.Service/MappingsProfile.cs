using AutoMapper;
using RP.Data;
using RP.DTO.Recipes;

namespace RP.Service
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Recipe, GetRecipeOutput>().ReverseMap();
            CreateMap<Recipe, GetAllRecipesOutput>().ReverseMap();
        }
    }
}