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
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController (IShoppingCartService shoppingCartService, IMapper mapper)
        {
            this. _shoppingCartService = shoppingCartService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ShoppingCartDTO>>> GetAllShoppingCart()
        {
            var shoppingCarts = await _shoppingCartService.GetAllShoppingCart();
            var shoppingCartResources = _mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartDTO>>(shoppingCarts);

            return Ok(shoppingCarts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCartDTO>> GetShoppingCartById(int id)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCartById(id);
            var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartDTO>(shoppingCart);

            return Ok(shoppingCartResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ShoppingCartDTO>> CreateShoppingCart([FromBody] SaveShoppingCartDTO saveShoppingCartResource)
        {

            var validator = new SaveShoppingCartResourceValidator();
            var validationResult = await validator.ValidateAsync(saveShoppingCartResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var shoppingCartToCreate = _mapper.Map<SaveShoppingCartDTO, ShoppingCart>(saveShoppingCartResource);

            var newShoppingCart = await _shoppingCartService.CreateShoppingCart(shoppingCartToCreate);

            var ShoppingCart = await _shoppingCartService.GetShoppingCartById(newShoppingCart.Id);

            var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartDTO>(ShoppingCart);

            return Ok(shoppingCartResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShoppingCartDTO>> UpdateShoppingCart(int id, [FromBody] SaveShoppingCartDTO saveShoppingCartResource)
        {
            var validator = new SaveShoppingCartResourceValidator();
            var validationResult = await validator.ValidateAsync(saveShoppingCartResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var shoppingCartToBeUpdated = await _shoppingCartService.GetShoppingCartById(id);

            if (shoppingCartToBeUpdated == null)
                return NotFound();

            var shoppingCart = _mapper.Map<SaveShoppingCartDTO, ShoppingCart>(saveShoppingCartResource);

            await _shoppingCartService.UpdateShoppingCart(shoppingCartToBeUpdated, shoppingCart);

            var updatedShoppingCart = await _shoppingCartService.GetShoppingCartById(id);
            var updatedshoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartDTO>(updatedShoppingCart);

            return Ok(updatedshoppingCartResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingCart(int id)
        {
            if (id == 0)
                return BadRequest("Invalid shopping cart ID.");

            var shoppingCart = await _shoppingCartService.GetShoppingCartById(id);

            if (shoppingCart == null)
                return NotFound();

            await _shoppingCartService.DeleteShoppingCart(shoppingCart);

            return NoContent();
        }
    }
}
