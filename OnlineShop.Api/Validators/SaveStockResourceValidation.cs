using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveStockResourceValidation: AbstractValidator<SaveStockDTO>
    {
        public SaveStockResourceValidation() 
        {
            RuleFor(p => p.StockID)
                .NotEmpty();
        }
    }
}
