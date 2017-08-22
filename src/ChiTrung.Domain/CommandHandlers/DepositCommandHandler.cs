using System;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Core.Notifications;
using ChiTrung.Domain.Events;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using MediatR;

namespace ChiTrung.Domain.CommandHandlers
{
    public class DepositCommandHandler : CommandHandler,
        INotificationHandler<DepositMoneyCommand>
    {
        private readonly IDepositRepository _depositRepository;
        private readonly IMediatorHandler Bus;

        public DepositCommandHandler(IDepositRepository depositRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _depositRepository = depositRepository;
            Bus = bus;
        }

        public void Handle(DepositMoneyCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var deposit = new Deposit(message.AccCode, message.TransactionDate, message.CusId, message.Amount, message.WitCode);

            if (_depositRepository.GetByDepCode(deposit.DepCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The code of the deposit has already been taken."));
                return;
            }

            _depositRepository.Add(deposit);

            if (Commit())
            {
                Bus.RaiseEvent(new DepositEvent(Guid.NewGuid(), deposit.DepCode, deposit.AccCode, deposit.TransactionDate, deposit.CusId, deposit.Amount, deposit.WitCode));
            }
        }

        public void Dispose()
        {
            _depositRepository.Dispose();
        }
    }
}