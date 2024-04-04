using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveAddressInformationResourceValidator : AbstractValidator<SaveAddressInformationDTO>
    {
        public SaveAddressInformationResourceValidator() 
        {
            RuleFor(p => p.County)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.street)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(p => p.zipcode)
                .NotEmpty();
        }
    }
}
