using FluentValidation;
using ShoeStore.Core.Models;

namespace ShoeStore.Core.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
        }
    }
}