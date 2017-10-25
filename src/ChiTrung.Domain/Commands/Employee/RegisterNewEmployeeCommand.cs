using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class RegisterNewEmployeeCommand : EmployeeCommand
    {
        public RegisterNewEmployeeCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewEmployeeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}