using ChiTrung.Domain.Events;
using MediatR;

namespace ChiTrung.Domain.EventHandlers
{
    public class AtmEventHandler :
        INotificationHandler<AtmAddedEvent>,
        INotificationHandler<AtmUpdatedEvent>
    {
        public void Handle(AtmAddedEvent message)
        {
            // Send some notification of bank
        }

        public void Handle(AtmUpdatedEvent message)
        {
            // Send some notification of bank
        }
    }
}