using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RP.DTO.Recipes;
using System;
using Xunit;

namespace RP.API.Tests.RecipeControllerTest
{
    public class GetTest : RecipeControllerTestBase
    {
        public GetTest() : base()
        {
        }

        [Fact]
        public async void Get_Should_Return_Recipe()
        {
            var recipe = Builder<GetRecipeOutput>.CreateNew().Build();
            recipeServiceMock.Setup(service => service.GetRecipe(recipe.Id))
                .ReturnsAsync(recipe);

            var result = await controller.Get(recipe.Id);

            var okResult = Assert.IsAssignableFrom<OkObjectResult>(result);
            var recipeResult = Assert.IsAssignableFrom<GetRecipeOutput>(okResult.Value);
            Assert.True(recipe.Id == recipeResult.Id);
        }

        [Fact]
        public async void Get_Should_Return_NotFound()
        {
            recipeServiceMock.Setup(service => service.GetRecipe(It.IsAny<Guid>()))
                .ReturnsAsync(() => null);

            var result = await controller.Get(Guid.NewGuid());

            Assert.IsAssignableFrom<NotFoundResult>(result);
        }
    }
}