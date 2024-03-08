using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.PromotionManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;
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
    }
}
