using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.StockManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController (IStockService stockService)
        {
            this. _stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStock()
        {
            var stocks = await _stockService.GetAllStock();
            return Ok(stocks);
        }

        //[HttpPost]
        //public async Task<ActionResult<Stock>> CreateStock([FromBody] Stock newStock)
        //{
        //    var addedStock = await _stockService.CreateStock(newStock);
        //    return Ok(addedStock);
        //}
    }
}
