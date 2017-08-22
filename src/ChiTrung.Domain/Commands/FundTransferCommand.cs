using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class FundTransferCommand : WithdrawalCommand
    {
        public FundTransferCommand(string witCode, string fromAccCode, string toAccCode, DateTime tDate, string cusId, double amount, string atmCode)
        {
            WitCode = witCode;
            AccCode = fromAccCode;
            ToAccCode = toAccCode;
            TransactionDate = tDate;
            CusId = cusId;
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