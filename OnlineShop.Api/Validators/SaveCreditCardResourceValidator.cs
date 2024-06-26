﻿using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveCreditCardResourceValidator: AbstractValidator<SaveCreditCardDTO>
    {
        public SaveCreditCardResourceValidator() 
        {
            RuleFor(p => p.CardHolderName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(p => p.ExpiryDate)
                .NotEmpty();
        }

    }
}
