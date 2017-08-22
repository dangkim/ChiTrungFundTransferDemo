using ChiTrung.Domain.Events;
using MediatR;

namespace ChiTrung.Domain.EventHandlers
{
    public class BankEventHandler :
        INotificationHandler<BankAddedEvent>,
        INotificationHandler<BankUpdatedEvent>
    {
        public void Handle(BankAddedEvent message)
        {
            // Send some notification of bank
        }

        public void Handle(BankUpdatedEvent message)
        {
            // Send some notification of bank
        }
    }
}