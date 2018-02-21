using Microsoft.AspNetCore.Mvc;
using RP.Service;
using System;
using System.Threading.Tasks;

namespace RP.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService service)
        {
            customerService = service;
        }

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await customerService.GetAllAsync());
        }

        /// <summary>
        /// Returns the specified customer
        /// </summary>
        /// <param name="id">Identifier of the customer</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var customer = await customerService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}