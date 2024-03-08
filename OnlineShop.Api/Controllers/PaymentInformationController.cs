using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentInformationController : ControllerBase
    {
        private readonly IPaymentInformationService _paymentInformationService;
        PaymentInformationController(IPaymentInformationService paymentInformationService)
        {
            this._paymentInformationService = paymentInformationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentInformation>>> GetAllPaymentInformation()
        {
            var paymentInformations = await _paymentInformationService.GetAllPaymentInformation();
            return Ok(paymentInformations);
        }
    }
}
