using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RP.DTO.Recipes;
using Xunit;

namespace RP.API.Tests.RecipeControllerTest
{
    public class PostTest : RecipeControllerTestBase
    {
        public PostTest() : base()
        {
            var recipeCreated = Builder<PostRecipeOutput>.CreateNew().Build();
            recipeServiceMock.Setup(s => s.Create(It.IsAny<PostRecipeInput>())).ReturnsAsync(recipeCreated);
        }

        [Fact]
        public async void WhenRecipeIsAdded_ReturnCreatedAtActionResult()
        {
            var ingredient = Builder<PostRecipeInput>.CreateNew().Build();

            var result = await controller.Post(ingredient);

            var okResult = Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            Assert.IsAssignableFrom<PostRecipeOutput>(okResult.Value);
        }

        [Fact]
        public async void WhenNullRecipe_ReturnBadRequest()
        {
            var result = await controller.Post(null);
            Assert.IsAssignableFrom<BadRequestResult>(result);
        }
    }
}