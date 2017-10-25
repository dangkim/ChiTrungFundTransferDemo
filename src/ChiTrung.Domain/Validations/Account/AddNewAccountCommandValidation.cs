using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class AddNewAccountCommandValidation : AccountValidation<AddNewAccountCommand>
    {
        public AddNewAccountCommandValidation()
        {
            ValidateAccCode();
            ValidateBankCode();
            ValidateCusId();
        }
    }
}