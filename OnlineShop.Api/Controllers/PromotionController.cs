using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.ProductManagement;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
        private readonly IMapper _mapper;

        public PromotionController (IPromotionService promotionService)
        {
            this. _promotionService = promotionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetAllPromotion()
        {
            var products = await _promotionService.GetAllPromotion();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<PromotionDTO>> CreatePromotion([FromBody] SavePromotionDTO savePromotionResource)
        {
            var validator = new SavePromotionResourceValidator();
            var validationResult = await validator.ValidateAsync(savePromotionResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var promotionToCreate = _mapper.Map<SavePromotionDTO, Promotion>(savePromotionResource); // Corrected mapping type to Promotion

            var newPromotion = await _promotionService.CreatePromotion(promotionToCreate);

            var promotionResource = _mapper.Map<Promotion, PromotionDTO>(newPromotion); // Corrected mapping type to Promotion

            return Ok(promotionResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PromotionDTO>> UpdatePromotion(int id, [FromBody] SavePromotionDTO savePromotionResource)
        {
            var validator = new SavePromotionResourceValidator();
            var validationResult = await validator.ValidateAsync(savePromotionResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var promotionToBeUpdated = await _promotionService.GetPromotionById(id);

            if (promotionToBeUpdated == null)
                return NotFound();

            _mapper.Map(savePromotionResource, promotionToBeUpdated);

            var updatedPromotionEntity = _mapper.Map<SavePromotionDTO, Promotion>(savePromotionResource);

            await _promotionService.UpdatePromotion(promotionToBeUpdated, updatedPromotionEntity);

            var updatedPromotion = await _promotionService.GetPromotionById(id);

            var promotionResource = _mapper.Map<Promotion, PromotionDTO>(updatedPromotion);

            return Ok(promotionResource);
        }

    }
}
