using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class RemoveEmployeeCommand : EmployeeCommand
    {
        public RemoveEmployeeCommand(int employeeId, string firstName, string lastName)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveEmployeeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}