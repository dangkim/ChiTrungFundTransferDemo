using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class WithdrawalAtmCommand : WithdrawalCommand
    {
        public WithdrawalAtmCommand(string witCode, string accCode, DateTime tDate, double amount, string atmCode)
        {
            WitCode = witCode;
            AccCode = accCode;
            TransactionDate = tDate;
            Amount = amount;
            AtmCode = atmCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new WithDrawalCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}