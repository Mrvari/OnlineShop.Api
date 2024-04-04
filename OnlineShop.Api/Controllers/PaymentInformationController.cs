using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentInformationController : ControllerBase

    {
        private readonly IPaymentInformationService _paymentInformationService;
        private readonly IMapper _mapper;
        PaymentInformationController(IPaymentInformationService paymentInformationService, IMapper mapper)
        {
            this._paymentInformationService = paymentInformationService;
            this._mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PaymentInformationDTO>>> GetAllPaymentInformation()
        {
            var paymentInformations = await _paymentInformationService.GetAllPaymentInformation();
            var paymentInformationResources = _mapper.Map<IEnumerable<PaymentInformation>, IEnumerable<PaymentInformationDTO>>(paymentInformations);

            return Ok(paymentInformationResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentInformationDTO>> GetPaymentInformationById(int id)
        {
            var paymentInformations = await _paymentInformationService.GetPaymentInformationById(id);
            var paymentInformationResource = _mapper.Map<PaymentInformation, PaymentInformationDTO>(paymentInformations);

            return Ok(paymentInformationResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<PaymentInformationDTO>> CreatePayment([FromBody] SavePaymentInformationDTO savePaymentInformationResource)
        {
            var validator = new SavePaymentInformationResourceValidator();

            var validationResult = await validator.ValidateAsync(savePaymentInformationResource);

            if (!validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors);

            var paymentInformationToCreate = _mapper.Map<SavePaymentInformationDTO, PaymentInformation>(savePaymentInformationResource);

            var newPaymentInformation = await _paymentInformationService.CreatePaymentInformation(paymentInformationToCreate);

            var paymentInformation = await _paymentInformationService.GetPaymentInformationById(newPaymentInformation.Id);

            var paymentResource = _mapper.Map<PaymentInformation, PaymentInformationDTO>(paymentInformation);

            return Ok(paymentResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentInformationDTO>> UpdatePayment(int id, [FromBody] SavePaymentInformationDTO savePaymentInformationResource)
        {
            var validator = new SavePaymentInformationResourceValidator();
            var validationResult = await validator.ValidateAsync(savePaymentInformationResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var paymentInformationToBeUpdated = await _paymentInformationService.GetPaymentInformationById(id);

            if (paymentInformationToBeUpdated == null)
                return NotFound();

            var paymentInformation = _mapper.Map<SavePaymentInformationDTO, PaymentInformation>(savePaymentInformationResource);

            await _paymentInformationService.UpdatePaymentInformation(paymentInformationToBeUpdated, paymentInformation);

            var updatedPaymentInformation = await _paymentInformationService.GetPaymentInformationById(id);
            var updatedpaymentInformationResource = _mapper.Map<PaymentInformation, PaymentInformationDTO>(updatedPaymentInformation);

            return Ok(updatedpaymentInformationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (id == 0)
                return BadRequest("Invalid payment information ID.");

            var paymentInformation = await _paymentInformationService.GetPaymentInformationById(id);

            if (paymentInformation == null)
                return NotFound();

            await _paymentInformationService.DeletePaymentInformation(paymentInformation);

            return NoContent();
        }
    }
}
