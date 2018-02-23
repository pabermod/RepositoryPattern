using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RP.API.Controllers;
using RP.DTO.Recipes;
using RP.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RP.API.Tests
{
    public class RecipeControllerTest
    {
        [Fact]
        public async Task Get_Should_Return_List_Of_Recipes()
        {
            int numRecipes = 20;
            var recipeList = Builder<GetAllRecipesOutput>.CreateListOfSize(numRecipes).Build().AsEnumerable();
            var recipeServiceMock = new Mock<IRecipeService>();
            recipeServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(recipeList);

            var controller = new RecipeController(recipeServiceMock.Object);
            var result = await controller.Get();

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<GetAllRecipesOutput>>(okResult.Value);
            Assert.True(recipes.Count() == numRecipes);
        }

        [Fact]
        public async Task Get_Should_Return_Empty()
        {
            var recipeServiceMock = new Mock<IRecipeService>();
            recipeServiceMock.Setup(service => service.GetAll())
                .ReturnsAsync(new List<GetAllRecipesOutput>());

            var controller = new RecipeController(recipeServiceMock.Object);
            var result = await controller.Get();

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<GetAllRecipesOutput>>(okResult.Value);
            Assert.False(recipes.Any());
        }
    }
}