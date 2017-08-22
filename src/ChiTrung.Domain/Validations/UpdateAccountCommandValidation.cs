using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class UpdateAccountCommandValidation : AccountValidation<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidation()
        {
            ValidateAccCode();
            ValidateBankCode();
            ValidateCusId();
        }
    }
}