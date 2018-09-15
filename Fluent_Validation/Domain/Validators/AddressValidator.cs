using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Line1).NotEmpty().WithMessage("Line 1 is required.");
            RuleFor(a => a.Country).NotEmpty().WithMessage("Country name is required.");
            RuleFor(a => a.Province).NotEmpty().WithMessage("Province/State name is required.");
            RuleFor(a => a.PostalCode).NotEmpty().WithMessage("Postal/Zip code is required.");
        }
    }
}
