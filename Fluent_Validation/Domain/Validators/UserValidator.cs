using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("First name is required.")
                .NotEqual("abc").WithMessage("First name 'abc' is not valid.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(u => u.Addresses).NotEmpty().WithMessage("User Address collection cannot be empty.")
                .Must(a => a.Count == 2).WithMessage("User Address collection count is not 2.");
        }
    }
}
