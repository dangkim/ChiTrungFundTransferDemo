using ChiTrung.Domain.Events;
using MediatR;

namespace ChiTrung.Domain.EventHandlers
{
    public class DepositEventHandler :
        INotificationHandler<DepositEvent>
    {
        public void Handle(DepositEvent message)
        {
            // Send some notification of bank
        }
    }
}