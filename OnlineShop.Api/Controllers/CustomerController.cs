using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

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

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] SaveCustomerDTO saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidatior();

            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            if (validationResult.IsValid) 
                return BadRequest(validationResult.Errors);

            var customerToCreate = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);

            var newCustomer = await _customerService.CreateCustomer(customerToCreate);

            var customer = await _customerService.GetCustomerById(newCustomer.CustomerID);

            var customerResource = _mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(customerResource);
        }

    }
}
