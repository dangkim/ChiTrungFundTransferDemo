using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class RegisterNewClientCommandValidation : ClientValidation<RegisterNewClientCommand>
    {
        public RegisterNewClientCommandValidation()
        {
            ValidateClientName();
            ValidateContactEmail();
            ValidateContactMobile();
        }
    }
}