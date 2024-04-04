using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this. _productService = productService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProduct()
        {
            var products = await _productService.GetAllProduct();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(productResources);
        }

        [HttpGet("id")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var products = await _productService.GetProductById(id);
            var productResources = _mapper.Map<Product, ProductDTO>(products);

            return Ok(productResources);
        }

        [HttpPost("")]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] SaveProductDTO saveProductResource)
        {

            var validator = new SaveProductResourceValidator();// product için gelen verileri doğrulamak için  sınıfı örnekler

            var validationResult = await validator.ValidateAsync(saveProductResource); //Bu satır, gelen müzik kaydı verilerinin doğruluğunu kontrol eder

            if (!validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors); 

            var productToCreate = _mapper.Map<SaveProductDTO, Product>(saveProductResource); //SaveProductDTO nesnesini product nesnesine dönüştürür

            var newProduct = await _productService.CreateProduct(productToCreate); //yeni oluşan ürünü db ye kaydetmek için bir istek yapar

            var product = await _productService.GetProductById(newProduct.Id); //yeni oluşan ürünün db den id si ile almak için istek yapar

            var productResource = _mapper.Map<Product, ProductDTO>(product);//db den alınan product nesnelerini, istemciye gönderilecek ProductDTO nesnesine dönüştürür

            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody] SaveProductDTO saveProductResource)
        {
            var validator = new SaveProductResourceValidator();
            var validationResult = await validator.ValidateAsync(saveProductResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var productToBeUpdated = await _productService.GetProductById(id);

            if (productToBeUpdated == null)
                return NotFound();

            var product = _mapper.Map<SaveProductDTO, Product>(saveProductResource);

            await _productService.UpdateProduct(productToBeUpdated, product);

            var updatedProduct = await _productService.GetProductById(id);
            var updatedproductResource = _mapper.Map<Product, ProductDTO>(updatedProduct);

            return Ok(updatedproductResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id == 0)
                return BadRequest("Invalid product ID.");

            var product = await _productService.GetProductById(id);

            if (product == null)
                return NotFound();

            await _productService.DeleteProduct(product);

            return NoContent();
        }

    }
}
