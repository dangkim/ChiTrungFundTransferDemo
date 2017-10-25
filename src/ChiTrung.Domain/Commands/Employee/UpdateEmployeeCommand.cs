using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class UpdateEmployeeCommand : EmployeeCommand
    {
        public UpdateEmployeeCommand(int employeeId, string firstName, string lastName)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateEmployeeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}