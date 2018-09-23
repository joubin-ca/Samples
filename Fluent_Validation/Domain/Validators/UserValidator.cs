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
            RuleFor(u => u.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ValidationMessageConstants.FIRST_NAME_CANNOT_BE_EMPTY_OR_NULL)
                .NotEqual("abc").WithMessage(ValidationMessageConstants.FIRST_NAME_CANNOT_BE_SET_TO_ABC);

            RuleFor(u => u.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ValidationMessageConstants.LAST_NAME_CANNOT_BE_EMPTY_OR_NULL);

            RuleFor(u => u.Addresses)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage(ValidationMessageConstants.USER_ADDRESS_COLLECTION_CANNOT_BE_EMPTY)
                .Must(a => a.Count == 2).WithMessage(ValidationMessageConstants.USER_ADDRESS_COLLECTION_COUNT_MUST_BE_EXACTLY_2);
        }
    }
}
