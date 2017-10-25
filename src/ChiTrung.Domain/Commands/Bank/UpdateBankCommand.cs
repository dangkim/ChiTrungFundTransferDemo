using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class UpdateBankCommand : BankCommand
    {
        public UpdateBankCommand(string bankCode, string bankName)
        {
            BankCode = bankCode;
            BankName = bankName;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBankCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}