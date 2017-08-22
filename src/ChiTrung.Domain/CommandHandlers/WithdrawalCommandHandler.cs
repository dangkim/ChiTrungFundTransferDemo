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
    public class WithdrawalCommandHandler : CommandHandler,
        INotificationHandler<WithdrawalAtmCommand>,
        INotificationHandler<FundTransferCommand>
    {
        private readonly IWithdrawalRepository _withdrawalRepository;
        private readonly IDepositRepository _depositRepository;
        private readonly IMediatorHandler Bus;

        public WithdrawalCommandHandler(IWithdrawalRepository withdrawalRepository,
                                        IDepositRepository depositRepository,
                                        IUnitOfWork uow,
                                        IMediatorHandler bus,
                                        INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _withdrawalRepository = withdrawalRepository;
            _depositRepository = depositRepository;
            Bus = bus;
        }

        public void Handle(WithdrawalAtmCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var wit = new Withdrawal(message.WitCode, message.AccCode, message.TransactionDate, message.Amount, message.AtmCode);

            if (_withdrawalRepository.GetByWitCode(wit.WitCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The code of the withdrawal has already been taken."));
                return;
            }

            _withdrawalRepository.Add(wit);

            if (Commit())
            {
                Bus.RaiseEvent(new WithdrawalEvent(Guid.NewGuid(), wit.WitCode, wit.AccCode, wit.TransactionDate, wit.Amount, wit.AtmCode));
            }
        }

        public void Handle(FundTransferCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var wit = new Withdrawal(message.WitCode, message.AccCode, message.TransactionDate, message.Amount, message.AtmCode);
            var deposit = new Deposit(message.ToAccCode, message.TransactionDate, message.CusId, message.Amount, message.WitCode);

            if (_withdrawalRepository.GetByWitCode(wit.WitCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The code of the withdrawal has already been taken."));
                return;
            }

            if (message.AccCode == message.ToAccCode)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The account of the withdrawal and deposit could not be matched"));
                return;
            }

            _withdrawalRepository.Add(wit);
            _depositRepository.Add(deposit);

            if (Commit())
            {
                Bus.RaiseEvent(new FundTransferEvent(Guid.NewGuid(), wit.WitCode, wit.AccCode, wit.TransactionDate, wit.Amount, wit.AtmCode));
            }
        }

        public void Dispose()
        {
            _withdrawalRepository.Dispose();
        }
    }
}