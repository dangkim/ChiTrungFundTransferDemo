using System;
using ChiTrung.Domain.Commands;
using FluentValidation;

namespace ChiTrung.Domain.Validations
{
    public abstract class ClientValidation<T> : AbstractValidator<T> where T : ClientCommand
    {
        protected void ValidateClientName()
        {
            RuleFor(c => c.ClientName)
                .NotEmpty().WithMessage("Please ensure you have entered the ClientName")
                .Length(2, 128).WithMessage("The Name must have between 2 and 128 characters");
        }

        protected void ValidateContactEmail()
        {
            RuleFor(c => c.ContactMail)
                .NotEmpty().WithMessage("Please ensure you have entered the ContactMail")
                .Length(2, 128).WithMessage("The Name must have between 2 and 128 characters");
        }

        protected void ValidateContactMobile()
        {
            RuleFor(c => c.ContactMobile)
                .NotEmpty().WithMessage("Please ensure you have entered the ContactMobile")
                .Length(2, 128).WithMessage("The Name must have between 2 and 128 characters");
        }

        protected void ValidateClientId()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(0)
                .NotEqual(int.MinValue);
        }
    }
}