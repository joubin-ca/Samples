using Domain;
using Domain.Validators;
using System;
using Xunit;
using System.Collections.Generic;

namespace UnitTests
{
    public class ValidationTests
    {
        [Fact]
        public void Test_Chaining_Validators()
        {
            // Property_Has_an_Invalid_value
            var user = new User
            {
                FirstName = "abc",
                LastName = "Smith",
                Addresses = new List<Address>()
            };

            var userValidator = new UserValidator();
            var validationResult = userValidator.Validate(user);

            if (!validationResult.IsValid)
                Console.WriteLine("Validation failed.");

            foreach (var result in validationResult.Errors)
            {
                Console.WriteLine($"Property '{result.PropertyName}' with message '{result.ErrorMessage}'");
            }

            Assert.False(validationResult.IsValid);
        }

        [Fact]
        public void Test_Validate_Property_Empty_or_Null()
        {
            var user = new User
            {
                FirstName = "John",
                LastName = ""
            };

            var userValidator = new UserValidator();
            var validationResult = userValidator.Validate(user);

            if (!validationResult.IsValid)
                Console.WriteLine("Validation failed.");

            foreach (var result in validationResult.Errors)
            {
                Console.WriteLine($"Property '{result.PropertyName}' with message '{result.ErrorMessage}'");
            }

            Assert.False(validationResult.IsValid);
        }
    }
}
