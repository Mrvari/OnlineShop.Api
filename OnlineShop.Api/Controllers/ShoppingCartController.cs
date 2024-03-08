using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
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
    }
}
