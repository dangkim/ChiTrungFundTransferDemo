using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class RegisterNewClientCommand : ClientCommand
    {
        public RegisterNewClientCommand(string clientName, string contactMobile, string contactMail)
        {
            ClientName = clientName;
            ContactMail = contactMobile;
            ContactMail = contactMail;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}