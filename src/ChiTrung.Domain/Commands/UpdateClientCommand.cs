using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class UpdateClientCommand : ClientCommand
    {
        public UpdateClientCommand(int clientId, string clientName, string contactMobile, string contactMail)
        {
            ClientId = clientId;
            ClientName = clientName;
            ContactMail = contactMobile;
            ContactMail = contactMail;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}