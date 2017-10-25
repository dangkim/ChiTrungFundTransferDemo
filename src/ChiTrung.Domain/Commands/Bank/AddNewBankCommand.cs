using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class AddNewBankCommand : BankCommand
    {
        public AddNewBankCommand(string bankCode, string bankName)
        {
            BankCode = bankCode;
            BankName = bankName;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewBankCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}