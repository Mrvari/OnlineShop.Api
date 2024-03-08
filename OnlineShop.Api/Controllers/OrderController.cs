using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            var orders = await _orderService.GetAllOrder();
            return Ok(orders);
        }
    }
}
