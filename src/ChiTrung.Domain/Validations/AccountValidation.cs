using System;
using ChiTrung.Domain.Commands;
using FluentValidation;

namespace ChiTrung.Domain.Validations
{
    public abstract class AccountValidation<T> : AbstractValidator<T> where T : AccountCommand
    {
        protected void ValidateAccCode()
        {
            RuleFor(c => c.AccCode)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the account")
                .Length(2, 20).WithMessage("The code must have between 2 and 20 characters");
        }

        protected void ValidateBankCode()
        {
            RuleFor(c => c.BankCode)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the bank")
                .Length(2, 20).WithMessage("The code must have between 2 and 20 characters");

        }

        protected void ValidateCusId()
        {
            RuleFor(c => c.CusId)
                .NotEmpty().WithMessage("Please ensure you have entered the code of the bank");

        }
    }
}