using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.StockManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService)
        {
            this._stockService = stockService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStock()
        {
            var stocks = await _stockService.GetAllStock();
            return Ok(stocks);
        }

        [HttpPost]
        public async Task<ActionResult<StockDTO>> CreateStock([FromBody] SaveStockDTO saveStockResource)
        {
            var validator = new SaveStockResourceValidatior();

            var validationResult = await validator.ValidateAsync(saveStockResource);

            if (validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var stockToCreate = _mapper.Map<SaveStockDTO, Stock>(saveStockResource);

            var newStock = await _stockService.CreateStock(stockToCreate);

            var stock = await _stockService.GetStockById(newStock.StockID);

            var stockResource = _mapper.Map<Stock, StockDTO>(stock);

            return Ok(stockResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StockDTO>> UpdateStock(int id, [FromBody] SaveStockDTO saveStockResource)
        {
            var validator = new SaveStockResourceValidatior();
            var validationResult = await validator.ValidateAsync(saveStockResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var stockToBeUpdated = await _stockService.GetStockById(id);

            if (stockToBeUpdated == null)
                return NotFound();

            _mapper.Map(saveStockResource, stockToBeUpdated);

            var updatedStockEntity = _mapper.Map<SaveStockDTO, Stock>(saveStockResource);

            await _stockService.UpdateStock(stockToBeUpdated, updatedStockEntity);

            var updatedStock = await _stockService.GetStockById(id);

            var stockResource = _mapper.Map<Stock, StockDTO>(updatedStock);

            return Ok(stockResource);
        }

    }
}
