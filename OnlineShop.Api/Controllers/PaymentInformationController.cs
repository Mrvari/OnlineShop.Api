using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentInformationController : ControllerBase

    {
        private readonly IPaymentInformationService _paymentInformationService;
        private readonly IMapper _mapper;
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

        [HttpPost]
        public async Task<ActionResult<PaymentInformationDTO>> CreatePayment([FromBody] SavePaymentInformationDTO savePaymentInformationResource)
        {
            var validator = new SavePaymentInformationResourceValidator();

            var validationResult = await validator.ValidateAsync(savePaymentInformationResource);

            if (validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors);

            var paymentInformationToCreate = _mapper.Map<SavePaymentInformationDTO, PaymentInformation>(savePaymentInformationResource);

            var newPaymentInformation = await _paymentInformationService.CreatePaymentInformation(paymentInformationToCreate);

            var paymentInformation = await _paymentInformationService.GetPaymentInformationById(newPaymentInformation.PaymentID);

            var paymentResource = _mapper.Map<PaymentInformation, PaymentInformationDTO>(paymentInformation);

            return Ok(newPaymentInformation);
        }
    }
}
