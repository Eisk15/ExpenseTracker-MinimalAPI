using FluentValidation;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Validators
{
    public class ExpenseValidator : AbstractValidator<Expense>
    {
        public ExpenseValidator()
        {
            RuleFor(e => e.Title).NotEmpty().WithMessage("Title is required!")
                .MinimumLength(5).WithMessage("Minimum length 5")
                .MaximumLength(100).WithMessage("Maximum length 100");
            RuleFor(e => e.Amount).GreaterThan(0);
            RuleFor(e => e.Description).NotEmpty().MaximumLength(500);
        }
    }
}
