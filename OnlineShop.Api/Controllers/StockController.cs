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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public StockController(IStockService stockService, IMapper mapper)
        {
            this._stockService = stockService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Stock>>> GetAllStock()
        {
            var stocks = await _stockService.GetAllStock();
            var stockResources = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockDTO>>(stocks);

            return Ok(stockResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockDTO>> GetStockById(int id)
        {
            var stocks = await _stockService.GetStockById(id);
            var stockResources = _mapper.Map<Stock , StockDTO>(stocks);

            return Ok(stockResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<StockDTO>> CreateStock([FromBody] SaveStockDTO saveStockResource)
        {
            var validator = new SaveStockResourceValidatior();
            var validationResult = await validator.ValidateAsync(saveStockResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var stockToCreate = _mapper.Map<SaveStockDTO, Stock>(saveStockResource);

            var newStock = await _stockService.CreateStock(stockToCreate);

            var stock = await _stockService.GetStockById(newStock.Id);

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

            var stock = _mapper.Map<SaveStockDTO, Stock>(saveStockResource);

            await _stockService.UpdateStock(stockToBeUpdated, stock);

            var updatedStock = await _stockService.GetStockById(id);
            var stockResource = _mapper.Map<Stock, StockDTO>(updatedStock);

            return Ok(stockResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            if (id == 0)
                return BadRequest("Invalid stock ID.");

            var stockObject = await _stockService.GetStockById(id);

            if (stockObject == null)
                return NotFound();

            await _stockService.DeleteStock(stockObject);

            return NoContent();
        }
    }
}
