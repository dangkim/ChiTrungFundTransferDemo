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
    public class BankCommandHandler : CommandHandler,
        INotificationHandler<AddNewBankCommand>,
        INotificationHandler<UpdateBankCommand>
    {
        private readonly IBankRepository _bankRepository;
        private readonly IMediatorHandler Bus;

        public BankCommandHandler(IBankRepository bankRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _bankRepository = bankRepository;
            Bus = bus;
        }

        public void Handle(AddNewBankCommand message)
        {
   
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var bank = new Bank(message.BankCode, message.BankName);

            if (_bankRepository.GetByBankCode(bank.BankCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The code of the bank has already been taken."));
                return;
            }

            _bankRepository.Add(bank);

            if (Commit())
            {
                Bus.RaiseEvent(new BankAddedEvent(Guid.NewGuid(), bank.BankCode, bank.BankName));
            }
        }

        public void Handle(UpdateBankCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var bank = new Bank(message.BankCode, message.BankName);
            var existingBank = _bankRepository.GetByBankCode(bank.BankCode);

            if (existingBank != null)
            {
                if (!existingBank.Equals(bank))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The bank has already been taken."));
                    return;
                }
            }

            _bankRepository.Update(bank);

            if (Commit())
            {
                Bus.RaiseEvent(new BankUpdatedEvent(Guid.NewGuid(), bank.BankCode, bank.BankName));
            }
        }

        public void Dispose()
        {
            _bankRepository.Dispose();
        }
    }
}