using FluentValidation;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).NotEmpty().WithMessage("Username is required!")
                .MinimumLength(5).WithMessage("Minimum length is 5!")
                .MaximumLength(20).WithMessage("Maximum Length is 20!");
            RuleFor(u => u.PasswordHash).NotEmpty().WithMessage("Password is required!")
                .MinimumLength(8).WithMessage("Minimum password length is 8");
        }
    }
}
