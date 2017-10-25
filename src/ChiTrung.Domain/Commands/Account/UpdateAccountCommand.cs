using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class UpdateAccountCommand : AccountCommand
    {
        public UpdateAccountCommand(string accCode, string bankCode, string cusId)
        {
            AccCode = accCode;
            BankCode = bankCode;
            CusId = cusId;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}