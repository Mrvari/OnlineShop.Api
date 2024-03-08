using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            var customers = await _customerService.GetAllCustomer();
            return Ok(customers);
        }
    }
}
