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

        public ReturnController(IReturnService returnService)
        {
            this. _returnService = returnService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Return>>> GetAllReturn()
        {
            var returns = await _returnService.GetAllReturn();
            return Ok(returns);
        }

        [HttpPost]
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
    }
}
