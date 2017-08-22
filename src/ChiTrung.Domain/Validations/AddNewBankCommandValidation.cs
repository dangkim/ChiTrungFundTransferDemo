using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class AddNewBankCommandValidation : BankValidation<AddNewBankCommand>
    {
        public AddNewBankCommandValidation()
        {
            ValidateBankCode();
            ValidateBankName();
        }
    }
}