using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class UpdateBankCommandValidation : BankValidation<UpdateBankCommand>
    {
        public UpdateBankCommandValidation()
        {
            ValidateBankCode();
            ValidateBankName();
        }
    }
}