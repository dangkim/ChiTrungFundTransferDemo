using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class UpdateAtmCommand : AtmCommand
    {
        public UpdateAtmCommand(string atmCode, string bankCode, string atmName)
        {
            AtmCode = atmCode;
            BankCode = bankCode;
            AtmName = AtmName;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAtmCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}