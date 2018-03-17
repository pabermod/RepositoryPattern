using Microsoft.AspNetCore.Mvc;
using RP.DTO.Recipes;
using RP.Service;
using System;
using System.Threading.Tasks;

namespace RP.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [Route("api")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService service)
        {
            recipeService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await recipeService.GetRecipes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var recipe = await recipeService.GetRecipe(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PostRecipeInput item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var recipe = await recipeService.Create(item);
            return CreatedAtAction("Get", new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }
            bool result = await recipeService.Delete(id);
            if (result)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}