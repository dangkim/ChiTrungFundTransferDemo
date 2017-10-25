using System;
using ChiTrung.Domain.Commands;
using FluentValidation;

namespace ChiTrung.Domain.Validations
{
    public abstract class AtmValidation<T> : AbstractValidator<T> where T : AtmCommand
    {
        protected void ValidateAtmName()
        {
            RuleFor(c => c.AtmName)
                .NotEmpty().WithMessage("Please ensure you have entered the name of the ATM")
                .Length(2, 100).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateAtmCode()
        {
            RuleFor(c => c.AtmCode)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the ATM")
                .Length(2, 20).WithMessage("The code must have between 2 and 20 characters");

        }

        protected void ValidateBankCode()
        {
            RuleFor(c => c.BankCode)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the bank")
                .Length(2, 20).WithMessage("The code must have between 2 and 20 characters");

        }
    }
}