using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveOrderResourceValidator: AbstractValidator<SaveOrderDTO>      
    {
        public SaveOrderResourceValidator() 
        {
            RuleFor(p => p.TotalAmount)
                .NotEmpty();

            RuleFor(p => p.OrderDate)
                .NotEmpty();

            RuleFor(p => p.OrderStatus)
                .NotEmpty();

            RuleFor(p => p.DeliveryAdress)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(p => p.TrackingNumber)
                .NotEmpty();
        }
    }
}
