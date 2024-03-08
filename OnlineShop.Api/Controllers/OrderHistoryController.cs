using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Repositories;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;
        public OrderHistoryController(IOrderHistoryService orderHistoryService)
        {
            this._orderHistoryService = orderHistoryService;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAllOrderHistory()
        {
            var OrderHistories = await _orderHistoryService.GetAllOrderHistory();
            return Ok(OrderHistories);
        }
    }
}
