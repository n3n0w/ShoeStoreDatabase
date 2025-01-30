using FluentValidation;
using ShoeStore.Core.Models;

namespace ShoeStore.Core.Validators
{
    public class ShoeValidator : AbstractValidator<Shoe>
    {
        public ShoeValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MaximumLength(100);
            RuleFor(s => s.Brand).NotEmpty().MaximumLength(50);
            RuleFor(s => s.Price).GreaterThan(0);
            RuleFor(s => s.Size).InclusiveBetween(1, 20);
        }
    }
}