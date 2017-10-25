using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class DepositMoneyCommandValidation : DepositValidation<DepositMoneyCommand>
    {
        public DepositMoneyCommandValidation()
        {
            //ValidateDepCode();
            ValidateAccCode();
            ValidateAmount();
            ValidateCusId();
            ValidateTransactionDate();
            //ValidateWitCode();
        }
    }
}