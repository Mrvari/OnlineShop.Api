using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        //productları databaseden çekip return edebilmek için ProductService'i controllerın içine eklememiz gerekiyor.
        //Bunu da constructor ile yapıyoruz
        public ProductController(IProductService productService, IMapper mapper)
        {
            this. _productService = productService;
            this._mapper = mapper;
        }


        //endpoint : İnternet ve ağ bağlamında endpoint, bir ağdaki iletişimin sonlandığı veya başladığı noktadır.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProduct()
        {
            var products = await _productService.GetAllProduct();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(productResources);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] SaveProductDTO saveProductResource)
        {

            var validator = new SaveProductResourceValidator();// product için gelen verileri doğrulamak için  sınıfı örnekler

            var validationResult = await validator.ValidateAsync(saveProductResource); //Bu satır, gelen müzik kaydı verilerinin doğruluğunu kontrol eder

            if (validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors); 

            var productToCreate = _mapper.Map<SaveProductDTO, Product>(saveProductResource); //SaveProductDTO nesnesini product nesnesine dönüştürür

            var newProduct = await _productService.CreateProduct(productToCreate); //yeni oluşan ürünü db ye kaydetmek için bir istek yapar

            var product = await _productService.GetProductById(newProduct.ProductID); //yeni oluşan ürünün db den id si ile almak için istek yapar

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

            _mapper.Map(saveProductResource, productToBeUpdated);

            var updatedProductEntity = _mapper.Map<SaveProductDTO, Product>(saveProductResource);

            await _productService.UpdateProduct(productToBeUpdated, updatedProductEntity);

            var updatedProduct = await _productService.GetProductById(id);

            var productResource = _mapper.Map<Product, ProductDTO>(updatedProduct);

            return Ok(productResource);
        }

    }
}
