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

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int id, [FromBody] SaveCustomerDTO saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidatior();

            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var customerToBeUpdated = await _customerService.GetCustomerById(id);

            if (customerToBeUpdated == null)
                return NotFound();

            _mapper.Map(saveCustomerResource, customerToBeUpdated);

            var updatedCustomerEntity = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);

            await _customerService.UpdateCustomer(customerToBeUpdated, updatedCustomerEntity);

            var updatedCustomer = await _customerService.GetCustomerById(id);

            var customerResource = _mapper.Map<Customer, CustomerDTO>(updatedCustomer);

            return Ok(customerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (id == 0)
                return BadRequest("Invalid customer ID.");

            var customer = await _customerService.GetCustomerById(id);

            if (customer == null)
                return NotFound();

            await _customerService.DeleteCustomer(customer);

            return NoContent();
        }
    }
}
