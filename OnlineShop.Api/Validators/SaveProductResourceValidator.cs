using FluentValidation;
using OnlineShop.Api.DTO;

//fluent validation : kullanıcı girdilerinin kolay ve sade bir şekilde doğrulanmasını sağlar
//Fluent validation kullanımının avantajları olarak kompleks şartların gerektiği durumlarda
//if-else kullanımının karmaşıklığını ortadan kaldırılabilir.

namespace OnlineShop.Api.Validators
{
    public class SaveProductResourceValidator : AbstractValidator<SaveProductDTO>
    {
        public SaveProductResourceValidator() 
        {

            RuleFor(p => p.ProductName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Price)
                .NotEmpty();

            RuleFor(p => p.Description)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(p => p.Images)
                .NotEmpty();

            RuleFor(p => p.Brand)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.TechnicalSpecifications)
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(p => p.Reviews)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.ReviewScores)
                .NotEmpty();
            
        }
    }
}
