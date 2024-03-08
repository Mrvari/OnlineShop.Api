using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveOrderHistoryResourceValidator : AbstractValidator<OrderHistoryDTO>
    {
        public SaveOrderHistoryResourceValidator() 
        {
            RuleFor(p => p.HistoryID)
               .NotEmpty();
        }
    }
}
