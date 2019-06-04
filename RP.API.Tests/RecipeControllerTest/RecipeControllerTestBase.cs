using Moq;
using RP.API.Controllers;
using RP.Service;
using System;

namespace RP.API.Tests.RecipeControllerTest
{
    public class RecipeControllerTestBase
    {
        protected Mock<IRecipeService> recipeServiceMock;
        protected RecipeController controller;

        public RecipeControllerTestBase()
        {
            recipeServiceMock = new Mock<IRecipeService>();
            controller = new RecipeController(recipeServiceMock.Object);
        }
    }
}