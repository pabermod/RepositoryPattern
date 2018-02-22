using Microsoft.AspNetCore.Mvc;
using RP.Service;
using System;
using System.Threading.Tasks;

namespace RP.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Recipe")]
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await recipeService.GetAllAsync());
        }

        /// <summary>
        /// Returns the specified customer
        /// </summary>
        /// <param name="id">Identifier of the customer</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var recipe = await recipeService.GetRecipeAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST: api/Recipe
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Recipe/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}