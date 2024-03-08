using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.OrderManagement;
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

        public ShoppingCartController (IShoppingCartService shoppingCartService)
        {
            this. _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetAllShoppingCart()
        {
            var shoppingCarts = await _shoppingCartService.GetAllShoppingCart();
            return Ok(shoppingCarts);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingCartDTO>> CreateShoppingCart([FromBody] SaveShoppingCartDTO saveShoppingCartResource)
        {

            var validator = new SaveShoppingCartResourceValidator();

            var validationResult = await validator.ValidateAsync(saveShoppingCartResource);

            if (validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var shoppingCartToCreate = _mapper.Map<SaveShoppingCartDTO, ShoppingCart>(saveShoppingCartResource);

            var newShoppingCart = await _shoppingCartService.CreateShoppingCart(shoppingCartToCreate);

            var ShoppingCart = await _shoppingCartService.GetShoppingCartById(newShoppingCart.CartID);

            var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartDTO>(ShoppingCart);

            return Ok(shoppingCartResource);
        }
    }
}
