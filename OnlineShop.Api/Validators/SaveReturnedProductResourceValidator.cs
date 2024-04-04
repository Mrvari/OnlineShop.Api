using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveReturnedProductResourceValidator: AbstractValidator<SaveReturnedProductDTO>
    {
        public SaveReturnedProductResourceValidator() 
        {
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
