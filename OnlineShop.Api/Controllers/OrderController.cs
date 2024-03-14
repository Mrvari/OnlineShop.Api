using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

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

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> CreateOrder([FromBody] SaveOrderDTO saveOrderResource)
        {
            var validator = new SaveOrderResourceValidator();

            var validationResult = await validator.ValidateAsync(saveOrderResource);

            if (validationResult.IsValid) 
                return BadRequest(validationResult.Errors);

            var orderToCreate = _mapper.Map<SaveOrderDTO, Order>(saveOrderResource);

            var newOrder = await _orderService.CreateOrder(orderToCreate);

            var order = await _orderService.GetOrderById(newOrder.OrderID);

            var orderResoruce = _mapper.Map<Order, OrderDTO>(order);

            return Ok(orderResoruce);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(int id, [FromBody] SaveOrderDTO saveOrderResource)
        {
            var validator = new SaveOrderResourceValidator();

            var validationResult = await validator.ValidateAsync(saveOrderResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var orderToBeUpdated = await _orderService.GetOrderById(id);

            if (orderToBeUpdated == null)
                return NotFound();

            _mapper.Map(saveOrderResource, orderToBeUpdated);

            var updatedOrderEntity = _mapper.Map<SaveOrderDTO, Order>(saveOrderResource);

            await _orderService.UpdateOrder(orderToBeUpdated, updatedOrderEntity);

            var updatedOrder = await _orderService.GetOrderById(id);

            var orderResource = _mapper.Map<Order, OrderDTO>(updatedOrder);

            return Ok(orderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id == 0)
                return BadRequest("Invalid order ID.");

            var order = await _orderService.GetOrderById(id);

            if (order == null)
                return NotFound();

            await _orderService.DeleteOrder(order);

            return NoContent();
        }

    }
}
