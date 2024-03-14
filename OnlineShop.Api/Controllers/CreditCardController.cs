using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;

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

        [HttpPut("{id}")]
        public async Task<ActionResult<CreditCardDTO>> UpdateCreditCard(int id, [FromBody] SaveCreditCardDTO saveCreditCardResource)
        {
            var validator = new SaveCreditCardResourceValidator();

            var validationResult = await validator.ValidateAsync(saveCreditCardResource);

            var requestIsInvalid = id == 0 || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var creditCardToBeUpdate = await _creditCardService.GetCreditCardById(id);

            if (creditCardToBeUpdate == null)
                return NotFound();

            _mapper.Map(saveCreditCardResource, creditCardToBeUpdate);

            var updatedCreditCardEntity = _mapper.Map<SaveCreditCardDTO, CreditCard>(saveCreditCardResource);

            await _creditCardService.UpdateCreditCard(creditCardToBeUpdate, updatedCreditCardEntity);

            var updatedCreditCard = await _creditCardService.GetCreditCardById(id);

            var creditCardResource = _mapper.Map<CreditCard, CreditCardDTO>(updatedCreditCard);

            return Ok(creditCardResource);
        }
    }
}
