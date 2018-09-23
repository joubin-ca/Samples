using Domain;
using Domain.Validators;
using System;
using Xunit;
using System.Collections.Generic;

/// <summary>
/// https://fluentvalidation.net/start
/// </summary>
namespace UnitTests
{
    public class ValidationTests
    {
        [Fact(Skip = "Need to fix.")]
        public void Test_On_Failure_Cascade_Mode_Continue()
        {
            // Property_Has_an_Invalid_value
            var user = new User
            {
                FirstName = "John",
                LastName = "",
                Addresses = new List<Address>()
            };

            var userValidator = new UserValidator();
            //userValidator.CascadeMode = FluentValidation.CascadeMode.Continue;
            var validationResult = userValidator.Validate(user);

            if (!validationResult.IsValid)
                Console.WriteLine("Validation failed.");

            foreach (var result in validationResult.Errors)
            {
                Console.WriteLine($"Property '{result.PropertyName}' with message '{result.ErrorMessage}'");
            }

            Assert.Equal(1, validationResult.Errors.Count);
            Assert.Equal(ValidationMessageConstants.LAST_NAME_CANNOT_BE_EMPTY_OR_NULL, validationResult.Errors[0].ErrorMessage);
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Test_Must_Phrase()
        {
            // Property_Has_an_Invalid_value
            var user = new User
            {
                FirstName = "John",
                LastName = "Smith",
                Addresses = {
                    new Address { Line1 = "line 1a", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Main },
                    new Address { Line1 = "line 1b", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Secondary },
                    new Address { Line1 = "line 1c", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Main }
                }
            };

            var userValidator = new UserValidator();
            var validationResult = userValidator.Validate(user);

            if (!validationResult.IsValid)
                Console.WriteLine("Validation failed.");

            foreach (var result in validationResult.Errors)
            {
                Console.WriteLine($"Property '{result.PropertyName}' with message '{result.ErrorMessage}'");
            }

            Assert.Equal(1, validationResult.Errors.Count);
            Assert.Equal(ValidationMessageConstants.USER_ADDRESS_COLLECTION_COUNT_MUST_BE_EXACTLY_2, validationResult.Errors[0].ErrorMessage);
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Test_Chaining_Validators()
        {
            // Property_Has_an_Invalid_value
            var user = new User
            {
                FirstName = "abc",
                LastName = "Smith",
                Addresses = {
                    new Address { Line1 = "line 1a", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Main },
                    new Address { Line1 = "line 1b", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Secondary }
                }
            };

            var userValidator = new UserValidator();
            var validationResult = userValidator.Validate(user);

            if (!validationResult.IsValid)
                Console.WriteLine("Validation failed.");

            foreach (var result in validationResult.Errors)
            {
                Console.WriteLine($"Property '{result.PropertyName}' with message '{result.ErrorMessage}'");
            }

            Assert.Equal(1, validationResult.Errors.Count);
            Assert.Equal(ValidationMessageConstants.FIRST_NAME_CANNOT_BE_SET_TO_ABC, validationResult.Errors[0].ErrorMessage);
            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Test_Validate_Property_Empty_or_Null()
        {
            var user = new User
            {
                FirstName = "John",
                LastName = "",
                Addresses = {
                    new Address { Line1 = "line 1a", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Main },
                    new Address { Line1 = "line 1b", Country = "Canada", Province = "ON", PostalCode = "H0H0H0", Type = AddressType.Secondary }
                }
            };

            var userValidator = new UserValidator();
            var validationResult = userValidator.Validate(user);

            if (!validationResult.IsValid)
                Console.WriteLine("Validation failed.");

            foreach (var result in validationResult.Errors)
            {
                Console.WriteLine($"Property '{result.PropertyName}' with message '{result.ErrorMessage}'");
            }

            Assert.Equal(1, validationResult.Errors.Count);
            Assert.Equal(ValidationMessageConstants.LAST_NAME_CANNOT_BE_EMPTY_OR_NULL, validationResult.Errors[0].ErrorMessage);
            Assert.False(validationResult.IsValid);
        }
    }
}
