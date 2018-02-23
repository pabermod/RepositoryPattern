using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RP.DTO.Recipes;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RP.API.Tests.RecipeControllerTest
{
    public class GetAllTest : RecipeControllerTestBase
    {
        public GetAllTest() : base()
        {
        }

        [Fact]
        public async void Get_Should_Return_List_Of_Recipes()
        {
            int numRecipes = 20;
            var recipeList = Builder<GetAllRecipesOutput>.CreateListOfSize(numRecipes).Build().AsEnumerable();
            recipeServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(recipeList);

            var result = await controller.Get();

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<GetAllRecipesOutput>>(okResult.Value);
            Assert.True(recipes.Count() == numRecipes);
        }

        [Fact]
        public async void Get_Should_Return_Empty()
        {
            var recipeList = new List<GetAllRecipesOutput>();
            recipeServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(recipeList);

            var result = await controller.Get();

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<GetAllRecipesOutput>>(okResult.Value);
            Assert.False(recipes.Any());
        }
    }
}