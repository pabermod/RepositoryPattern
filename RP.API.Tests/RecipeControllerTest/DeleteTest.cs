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
    public class DeleteTest : RecipeControllerTestBase
    {
        public DeleteTest() : base()
        {
        }

        [Fact]
        public async void WhenIdIsEmpty_ReturnBadRequest()
        {
            var result = await controller.Delete(Guid.Empty);

            Assert.IsAssignableFrom<BadRequestResult>(result);
        }

        [Fact]
        public async void WhenRecipeDoesNotExist_ReturnNotFound()
        {
            recipeServiceMock.Setup(service => service.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(false);

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async void WhenRecipesExist_ReturnNoContent()
        {
            recipeServiceMock.Setup(service => service.Delete(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            var result = await controller.Delete(Guid.NewGuid());

            Assert.IsAssignableFrom<NoContentResult>(result);
        }
    }
}