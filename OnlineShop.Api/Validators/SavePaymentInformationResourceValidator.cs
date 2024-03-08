using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SavePaymentInformationResourceValidator: AbstractValidator<SavePaymentInformationDTO>
    {
        public SavePaymentInformationResourceValidator() 
        {
            RuleFor(p => p.PaymentID)
                .NotEmpty();

            RuleFor(p => p.PaymentDate)
                .NotEmpty();

            RuleFor(p => p.PaymentType)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.PaymentStatus)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(p => p.PaymentAmount)
                .NotEmpty();
        }
    }
}
