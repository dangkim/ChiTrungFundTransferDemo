using ChiTrung.Domain.Events;
using MediatR;

namespace ChiTrung.Domain.EventHandlers
{
    public class AccountEventHandler :
        INotificationHandler<AccountAddedEvent>,
        INotificationHandler<AccountUpdatedEvent>
    {
        public void Handle(AccountAddedEvent message)
        {
            // Send some notification of bank
        }

        public void Handle(AccountUpdatedEvent message)
        {
            // Send some notification of bank
        }
    }
}