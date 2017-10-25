using System;
using ChiTrung.Domain.Commands;
using FluentValidation;

namespace ChiTrung.Domain.Validations
{
    public abstract class WithdrawalValidation<T> : AbstractValidator<T> where T : WithdrawalCommand
    {
        //protected void ValidateWitCode()
        //{
        //    RuleFor(c => c.WitCode)
        //        .NotEmpty().WithMessage("Please ensure you have entered the code of the withdrawal");
        //}

        protected void ValidateAccCode()
        {
            RuleFor(c => c.AccCode)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the account")
                .Length(2, 20).WithMessage("The code must have between 2 and 20 characters");

        }

        protected void ValidateAmount()
        {
            RuleFor(c => c.Amount)
                .NotEmpty().WithMessage("Please ensure you have entered an amount of the deposite")
                .GreaterThan(0.0).WithMessage("Please ensure you have entered the number that greater than 0.0");

        }

        //protected void ValidateAtmCode()
        //{
        //    RuleFor(c => c.AtmCode)
        //        .NotEmpty().WithMessage("Please ensure you have entered the code of the ATM")
        //        .Length(2, 20).WithMessage("The code must have between 2 and 20 characters");

        //}

        protected void ValidateTransactionDate()
        {
            RuleFor(c => c.TransactionDate)
                .NotEmpty().WithMessage("Please ensure you have entered the transaction date");
        }
    }
}