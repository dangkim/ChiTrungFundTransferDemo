using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class AddNewAtmCommand : AtmCommand
    {
        public AddNewAtmCommand(string atmCode, string bankCode, string atmName)
        {
            AtmCode = atmCode;
            BankCode = bankCode;
            AtmName = AtmName;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewAtmCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}