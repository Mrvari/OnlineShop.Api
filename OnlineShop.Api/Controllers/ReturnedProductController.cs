using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnedProductController : ControllerBase
    {
        private readonly IReturnedProductService _returnedProductService;
        private readonly IMapper _mapper;

        public ReturnedProductController(IReturnedProductService returnedProductService, IMapper mapper)
        {
            this. _returnedProductService = returnedProductService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ReturnedProductDTO>>> GetAllReturnedProduct()
        {
            var returnedProduct = await _returnedProductService.GetAllReturnedProduct();
            var returnedProductResources = _mapper.Map<IEnumerable<ReturnedProduct>, IEnumerable<ReturnedProductDTO>>(returnedProduct);

            return Ok(returnedProduct);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnedProductDTO>> GetReturnedProductById(int id)
        {
            var returnedProduct = await _returnedProductService.GetReturnedProductById(id);
            var returnedProductResources = _mapper.Map<ReturnedProduct, ReturnedProductDTO>(returnedProduct);

            return Ok(returnedProductResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<ReturnedProductDTO>> CreateReturnedProduct([FromBody] SaveReturnedProductDTO saveReturnedProductResource)
        {

            var validator = new SaveReturnedProductResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReturnedProductResource); 

            if (validationResult.IsValid) 
                return BadRequest(validationResult.Errors);

            var returnedProductToCreate = _mapper.Map<SaveReturnedProductDTO, ReturnedProduct>(saveReturnedProductResource); 

            var newReturnedProduct = await _returnedProductService.CreateReturnedProduct(returnedProductToCreate); 

            var ReturnedProducts = await _returnedProductService.GetReturnedProductById(newReturnedProduct.Id); 

            var returnedProductResource = _mapper.Map<ReturnedProduct, ReturnedProductDTO>(ReturnedProducts);

            return Ok(returnedProductResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnedProductDTO>> UpdateReturnedProduct(int id, [FromBody] SaveReturnedProductDTO saveReturnedProductResource)
        {
            var validator = new SaveReturnedProductResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReturnedProductResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var returnedProductToBeUpdated = await _returnedProductService.GetReturnedProductById(id);

            if (returnedProductToBeUpdated == null)
                return NotFound();

            var rReturnedProducts = _mapper.Map<SaveReturnedProductDTO, ReturnedProduct>(saveReturnedProductResource);

            await _returnedProductService.UpdateReturnedProduct(returnedProductToBeUpdated, rReturnedProducts);

            var updatedReturn = await _returnedProductService.GetReturnedProductById(id);

            var updatedreturnResource = _mapper.Map<ReturnedProduct, ReturnedProductDTO>(updatedReturn);

            return Ok(updatedreturnResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturnedProduct(int id)
        {
            if (id == 0)
                return BadRequest("Invalid return ID.");

            var returnedProductObject = await _returnedProductService.GetReturnedProductById(id);

            if (returnedProductObject == null)
                return NotFound();

            await _returnedProductService.DeleteReturnedProduct(returnedProductObject);

            return NoContent();
        }

    }
}
