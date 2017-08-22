using ChiTrung.Domain.Events;
using MediatR;

namespace ChiTrung.Domain.EventHandlers
{
    public class WithdrawalEventHandler :
        INotificationHandler<WithdrawalEvent>,
        INotificationHandler<FundTransferEvent>
    {
        public void Handle(WithdrawalEvent message)
        {
            // Send some notification of bank
        }

        public void Handle(FundTransferEvent message)
        {
            // Send some notification of bank
        }
    }
}