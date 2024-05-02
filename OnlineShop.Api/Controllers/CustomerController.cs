using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;
using Microsoft.Extensions.Logging;
using System;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, IMapper mapper, ILogger<CustomerController> logger)
        {
            this._customerService = customerService;
            this._mapper = mapper;
            this._logger = logger;
        }

        [HttpGet("")]

        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomer()
        {
            try
            {
                var customers = await _customerService.GetAllCustomer();
                var customerResources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);

                return Ok(customerResources);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all customers.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                if (customer == null)
                {
                    _logger.LogInformation("Customer with ID {CustomerId} not found.", id);
                    return NotFound();
                }

                var customerResource = _mapper.Map<Customer, CustomerDTO>(customer);
                return Ok(customerResource);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving customer with ID {CustomerId}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<CustomerDTO>> CreateCustomer([FromBody] SaveCustomerDTO saveCustomerResource)
        {
            try
            {
                var validator = new SaveCustomerResourceValidatior();
                var validationResult = await validator.ValidateAsync(saveCustomerResource);

                if (!validationResult.IsValid)
                    return BadRequest(validationResult.Errors);

                var customerToCreate = _mapper.Map<SaveCustomerDTO, Customer>(saveCustomerResource);
                var newCustomer = await _customerService.CreateCustomer(customerToCreate);

                var customerResource = _mapper.Map<Customer, CustomerDTO>(newCustomer);

                HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
                HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");

                return Ok(customerResource);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new customer.");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int id, [FromBody] SaveCustomerDTO saveCustomerResource)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating customer with ID {CustomerId}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Invalid customer ID.");

                var customer = await _customerService.GetCustomerById(id);

                if (customer == null)
                    return NotFound();

                await _customerService.DeleteCustomer(customer);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting customer with ID {CustomerId}.", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
