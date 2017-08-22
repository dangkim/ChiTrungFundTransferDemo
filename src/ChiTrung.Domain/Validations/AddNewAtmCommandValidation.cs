using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class AddNewAtmCommandValidation : AtmValidation<AddNewAtmCommand>
    {
        public AddNewAtmCommandValidation()
        {
            ValidateAtmName();
            ValidateAtmCode();
            ValidateBankCode();
        }
    }
}