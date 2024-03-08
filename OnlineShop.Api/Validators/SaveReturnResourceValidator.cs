using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveReturnResourceValidator: AbstractValidator<SaveReturnDTO>
    {
        public SaveReturnResourceValidator() 
        {
            RuleFor(p => p.ReturnID)
                .NotEmpty();

            RuleFor(p => p.ReturnReason)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(p => p.ReturnDate)
                .NotEmpty();

            RuleFor(p => p.QuantityReturned)
                .NotEmpty();

            RuleFor(p => p.RefaundAmount)
                .NotEmpty();
        }
    }
}
