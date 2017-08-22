using System;
using ChiTrung.Domain.Commands;
using FluentValidation;

namespace ChiTrung.Domain.Validations
{
    public abstract class BankValidation<T> : AbstractValidator<T> where T : BankCommand
    {
        protected void ValidateBankName()
        {
            RuleFor(c => c.BankName)
                .NotEmpty().WithMessage("Please ensure you have entered the name of the bank")
                .Length(2, 100).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateBankCode()
        {
            RuleFor(c => c.BankCode)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the bank")
                .Length(2, 20).WithMessage("The Name must have between 2 and 20 characters");

        }
    }
}