using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveCustomerResourceValidatior: AbstractValidator<SaveCustomerDTO>
    {
        public SaveCustomerResourceValidatior() 
        {
            RuleFor(p => p.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.email)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Password)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
