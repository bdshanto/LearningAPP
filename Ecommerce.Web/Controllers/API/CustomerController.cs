using System.Linq;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.API
{
    public class CustomerController : ControllerBase
    {
        private ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        [Route("api/{controller}")]
        public IActionResult Get()
        {
            var customers = _customerManager.GetAll();
            if (customers !=null && customers.Any())
            {
                return Ok(customers);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Customer model)
        {
            if (ModelState.IsValid)
            {
                var isAdded = _customerManager.Add(model);
                if (isAdded)
                {
                    return Ok(model);
                }
            }

            return BadRequest(ModelState);
        }
    }
}