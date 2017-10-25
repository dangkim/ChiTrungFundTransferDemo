using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class RemoveClientCommand : ClientCommand
    {
        public RemoveClientCommand(int clientId)
        {
            ClientId = clientId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveClientCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}