using System;
using ChiTrung.Domain.Validations;

namespace ChiTrung.Domain.Commands
{
    public class DepositMoneyCommand : DepositCommand
    {
        public DepositMoneyCommand(int depCode, string accCode
            , DateTime tDate
            , string cusId
            , double amount
            , string witCode)
        {
            DepCode = depCode;
            AccCode = accCode;
            TransactionDate = tDate;
            CusId = cusId;
            Amount = amount;
            WitCode = witCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new DepositMoneyCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}