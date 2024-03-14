using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _returnService;
        private readonly IMapper _mapper;

        public ReturnController(IReturnService returnService, IMapper mapper)
        {
            this. _returnService = returnService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ReturnDTO>>> GetAllReturn()
        {
            var returns = await _returnService.GetAllReturn();
            var returnResources = _mapper.Map<IEnumerable<Return>, IEnumerable<ReturnDTO>>(returns);

            return Ok(returns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnDTO>> GetReturnById(int id)
        {
            var returns = await _returnService.GetReturnById(id);
            var returnResources = _mapper.Map<Return, ReturnDTO>(returns);

            return Ok(returnResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<ReturnDTO>> CreateReturn([FromBody] SaveReturnDTO saveReturnResource)
        {

            var validator = new SaveReturnResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReturnResource); 

            if (validationResult.IsValid) 
                return BadRequest(validationResult.Errors);

            var returnToCreate = _mapper.Map<SaveReturnDTO, Return>(saveReturnResource); 

            var newReturn = await _returnService.CreateReturn(returnToCreate); 

            var Return = await _returnService.GetReturnById(newReturn.ReturnID); 

            var returnResource = _mapper.Map<Return, ReturnDTO>(Return);

            return Ok(returnResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnDTO>> UpdateReturn(int id, [FromBody] SaveReturnDTO saveReturnResource)
        {
            var validator = new SaveReturnResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReturnResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var returnToBeUpdated = await _returnService.GetReturnById(id);

            if (returnToBeUpdated == null)
                return NotFound();

            var returns = _mapper.Map<SaveReturnDTO, Return>(saveReturnResource);

            await _returnService.UpdateReturn(returnToBeUpdated, returns);

            var updatedReturn = await _returnService.GetReturnById(id);

            var updatedreturnResource = _mapper.Map<Return, ReturnDTO>(updatedReturn);

            return Ok(updatedreturnResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturn(int id)
        {
            if (id == 0)
                return BadRequest("Invalid return ID.");

            var returnObject = await _returnService.GetReturnById(id);

            if (returnObject == null)
                return NotFound();

            await _returnService.DeleteReturn(returnObject);

            return NoContent();
        }

    }
}
