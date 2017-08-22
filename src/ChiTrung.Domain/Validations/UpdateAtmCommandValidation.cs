using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class UpdateAtmCommandValidation : AtmValidation<UpdateAtmCommand>
    {
        public UpdateAtmCommandValidation()
        {
            ValidateAtmName();
            ValidateAtmCode();
            ValidateBankCode();
        }
    }
}