using AutoMapper;
using RP.Data;
using RP.DTO.Recipes;

namespace RP.Service
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<PostRecipeInput, Recipe>();
        }
    }
}