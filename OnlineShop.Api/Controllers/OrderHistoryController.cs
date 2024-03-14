using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Repositories;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;
        private readonly IMapper _mapper;
        public OrderHistoryController(IOrderHistoryService orderHistoryService, IMapper mapper)
        {
            this._orderHistoryService = orderHistoryService;
            this._mapper = mapper;
        }

        [HttpGet("")]

        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetAllOrderHistory()
        {
            var orderHistories = await _orderHistoryService.GetAllOrderHistory();
            var orderHistoryResources = _mapper.Map<IEnumerable<OrderHistory>, IEnumerable<OrderHistoryDTO>>(orderHistories);
          
            return Ok(orderHistoryResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHistoryDTO>> GetOrderHistoryById(int id)
        {
            var orderHistory = await _orderHistoryService.GetOrderHistoryById(id);
            var orderHistoryResource = _mapper.Map<OrderHistory, OrderHistoryDTO>(orderHistory);

            return Ok(orderHistoryResource);
        }

        [HttpPost]
        public async Task<ActionResult<OrderHistoryDTO>> CreateOrderHistory([FromBody] SaveOrderHistoryDTO saveOrderHistoryResource)
        {
            var validator = new SaveOrderHistoryResourceValidator();

            //var validationResult = await validator.ValidateAsync(saveOrderHistoryResource);

            //if (!validationResult.IsValid) // Doğrulama sonucunu kontrol eder
            //    return BadRequest(validationResult.Errors);

            var orderHistoryToCreate = _mapper.Map<SaveOrderHistoryDTO, OrderHistory>(saveOrderHistoryResource);

            var newOrderHistory = await _orderHistoryService.CreateOrderHistory(orderHistoryToCreate);

            var orderHistoryResource = _mapper.Map<OrderHistory, OrderHistoryDTO>(newOrderHistory);

            return Ok(orderHistoryResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderHistoryDTO>> UpdateOrderHistory(int id, [FromBody] SaveOrderHistoryDTO saveOrderHistoryResource)
        {
            var validator = new SaveOrderHistoryResourceValidator();

            //var validationResult = await validator.ValidateAsync(saveOrderHistoryResource);

            //var requestIsInvalid = id == 0 || !validationResult.IsValid;

           // if (requestIsInvalid)
                //return BadRequest(validationResult.Errors);

            var orderHistoryToBeUpdated = await _orderHistoryService.GetOrderHistoryById(id);

            if (orderHistoryToBeUpdated == null)
                return NotFound();

            _mapper.Map(saveOrderHistoryResource, orderHistoryToBeUpdated);

            var updatedOrderHistoryEntity = _mapper.Map<SaveOrderHistoryDTO, OrderHistory>(saveOrderHistoryResource);

            await _orderHistoryService.UpdateOrderHistory(orderHistoryToBeUpdated, updatedOrderHistoryEntity);

            var updatedOrderHistory = await _orderHistoryService.GetOrderHistoryById(id);

            var orderHistoryResource = _mapper.Map<OrderHistory, OrderHistoryDTO>(updatedOrderHistory);

            return Ok(orderHistoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderHistory(int id)
        {
            if (id == 0)
                return BadRequest("Invalid order history ID.");

            var orderHistory = await _orderHistoryService.GetOrderHistoryById(id);

            if (orderHistory == null)
                return NotFound();

            await _orderHistoryService.DeleteOrderHistory(orderHistory);

            return NoContent();
        }

    }
}
