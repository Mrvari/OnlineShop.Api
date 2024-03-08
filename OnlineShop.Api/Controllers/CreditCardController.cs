using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        public CreditCardController(ICreditCardService creditCardService)
        {
            this._creditCardService = creditCardService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetAllCreditCard()
        {
            var creditCards = await _creditCardService.GetAllCreditCard();
            return Ok(creditCards);
        }
    }
}
