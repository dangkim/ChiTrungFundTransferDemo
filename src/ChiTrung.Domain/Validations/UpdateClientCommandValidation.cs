using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class UpdateClientCommandValidation : ClientValidation<UpdateClientCommand>
    {
        public UpdateClientCommandValidation()
        {
            ValidateClientId();
            ValidateContactEmail();
            ValidateContactMobile();
            ValidateClientName();
        }
    }
}