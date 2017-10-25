using ChiTrung.Domain.Commands;

namespace ChiTrung.Domain.Validations
{
    public class RemoveClientCommandValidation : ClientValidation<RemoveClientCommand>
    {
        public RemoveClientCommandValidation()
        {
            ValidateClientId();
        }
    }
}