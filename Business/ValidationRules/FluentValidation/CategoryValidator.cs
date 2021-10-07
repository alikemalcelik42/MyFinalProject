using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.CategoryName).MinimumLength(2);
            RuleFor(p => p.CategoryName).NotEmpty();
        }
    }
}
