using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveStockResourceValidatior: AbstractValidator<SaveStockDTO>
    {
        public SaveStockResourceValidatior() 
        {
            RuleFor(p => p.StockID)
                .NotEmpty();
        }
    }
}
