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

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            this._customerService = customerService;
            this._mapper = mapper;
        }

        [HttpGet("")]

        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomer()
        {
            var customers = await _customerService.GetAllCustomer();
            var customerResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

            return Ok(customerResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            var customerResource = _mapper.Map<Customer, CustomerDTO>(customer);

            return Ok(customerResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] SaveCustomerDTO saveCustomerResource)
        {
            var validator = new SaveCustomerResourceValidatior();
            var validationResult = await validator.ValidateAsync(saveCustomerResource);

            if (!validationResult.IsValid) 
                return BadRequest(validationResult.Errors);

            var customerToCreate = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);
            var newCustomer = await _customerService.CreateCustomer(customerToCreate);
            var customerResource = _mapper.Map<Customer, CustomerDTO>(newCustomer);

            return CreatedAtAction(nameof(GetCustomerById), new { id = customerResource.CustomerID }, customerResource);
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

            var customer = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);

            await _customerService.UpdateCustomer(customerToBeUpdated, customer);

            var updatedCustomer = await _customerService.GetCustomerById(id);
            var updatedcustomerResource = _mapper.Map<Customer, CustomerDTO>(updatedCustomer);

            return Ok(updatedcustomerResource);
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
