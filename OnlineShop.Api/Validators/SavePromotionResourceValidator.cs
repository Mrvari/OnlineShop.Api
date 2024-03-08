using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SavePromotionResourceValidator: AbstractValidator<SavePromotionDTO>
    {
        public SavePromotionResourceValidator() 
        {
            RuleFor(p => p.PromotionID)
                .NotEmpty();

            RuleFor(p => p.Cuponcode)
                .NotEmpty();

            RuleFor(p => p.DiscountAmount)
                .NotEmpty();

            RuleFor(p => p.ExpireDate)
                .NotEmpty();
        }
    }
}
