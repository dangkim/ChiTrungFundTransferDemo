using System;
using ChiTrung.Domain.Commands;
using FluentValidation;

namespace ChiTrung.Domain.Validations
{
    public abstract class EmployeeValidation<T> : AbstractValidator<T> where T : EmployeeCommand
    {
        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the FirstName")
                .Length(2, 64).WithMessage("The FirstName must have between 2 and 64 characters");
        }

        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Please ensure you have entered the LastName")
                .Length(2, 64).WithMessage("The LastName must have between 2 and 64 characters");
        }

        protected void ValidateEmployeeId()
        {
            RuleFor(c => c.EmployeeId)
                .NotEqual(0)
                .NotEqual(int.MinValue);
        }
    }
}