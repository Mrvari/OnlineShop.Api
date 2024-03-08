using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _creditCardService;
        private readonly IMapper _mapper;
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

        [HttpPost]
        public async Task<ActionResult<CreditCardDTO>> CreateCreditCard([FromBody] SaveCreditCardDTO saveCreditCardResource)
        {
            var validator = new SaveCreditCardResourceValidator();

            var validationResult = await validator.ValidateAsync(saveCreditCardResource);

            if (validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors);

            var creditCardToCreate = _mapper.Map<SaveCreditCardDTO, CreditCard>(saveCreditCardResource);

            var newCreditCard = await _creditCardService.CreateCreditCard(creditCardToCreate);

            var creditCard = await _creditCardService.GetCreditCardById(newCreditCard.CardID);

            var creditCardResource = _mapper.Map<CreditCard, CreditCardDTO>(creditCard);

            return Ok(creditCardResource);
        }
    }
}
