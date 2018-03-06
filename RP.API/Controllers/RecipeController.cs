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

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await recipeService.GetAll());
        }

        /// <summary>
        /// Returns the specified customer
        /// </summary>
        /// <param name="id">Identifier of the customer</param>
        /// <returns></returns>
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

        // POST: api/Recipe
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

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}