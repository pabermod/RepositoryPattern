using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RP.DTO.Recipes;
using System;
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
        public async void WhenRecipesExist_ReturnRecipes()
        {
            Random rand = new Random();
            int numRecipes = rand.Next(100);
            var recipeList = Builder<GetAllRecipesOutput>.CreateListOfSize(numRecipes).Build().AsEnumerable();

            recipeServiceMock.Setup(service => service.GetRecipes())
                .ReturnsAsync(recipeList);

            var result = await controller.Get();

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<GetAllRecipesOutput>>(okResult.Value);
            Assert.True(recipes.Count() == numRecipes);
        }

        [Fact]
        public async void WhenNoRecipes_ReturnEmpty()
        {
            var recipeList = new List<GetAllRecipesOutput>();
            recipeServiceMock.Setup(service => service.GetRecipes())
                .ReturnsAsync(recipeList);

            var result = await controller.Get();

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipes = Assert.IsAssignableFrom<IEnumerable<GetAllRecipesOutput>>(okResult.Value);
            Assert.False(recipes.Any());
        }
    }
}