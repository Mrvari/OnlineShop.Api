using FluentValidation;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Validators
{
    public class SaveShoppingCartResourceValidator: AbstractValidator<SaveShoppingCartDTO>
    {
        public SaveShoppingCartResourceValidator()
        {
        }
    }
}
