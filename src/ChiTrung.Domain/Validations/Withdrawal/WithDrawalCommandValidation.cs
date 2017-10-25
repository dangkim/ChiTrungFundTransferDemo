using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class WithDrawalCommandValidation : WithdrawalValidation<WithdrawalCommand>
    {
        public WithDrawalCommandValidation()
        {
            //ValidateWitCode();
            ValidateAccCode();
            ValidateAmount();
            //ValidateAtmCode();
            ValidateTransactionDate();
        }
    }
}