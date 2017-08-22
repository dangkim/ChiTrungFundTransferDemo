using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class AddNewAccountCommand : AccountCommand
    {
        public AddNewAccountCommand(string accCode, string bankCode, string cusId)
        {
            AccCode = accCode;
            BankCode = bankCode;
            cusId = CusId;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewAccountCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}