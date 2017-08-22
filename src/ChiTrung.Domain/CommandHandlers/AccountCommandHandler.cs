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
    public class AccountCommandHandler : CommandHandler,
        INotificationHandler<AddNewAccountCommand>,
        INotificationHandler<UpdateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMediatorHandler Bus;

        public AccountCommandHandler(IAccountRepository accountRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _accountRepository = accountRepository;
            Bus = bus;
        }

        public void Handle(AddNewAccountCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var account = new Account(message.AccCode, message.CusId, message.BankCode);

            if (_accountRepository.GetByAccCode(account.AccCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The code of the Account has already been taken."));
                return;
            }

            _accountRepository.Add(account);

            if (Commit())
            {
                Bus.RaiseEvent(new AccountAddedEvent(Guid.NewGuid(), account.AccCode, account.CusId, account.BankCode));
            }
        }

        public void Handle(UpdateAccountCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var account = new Account(message.AccCode, message.CusId, message.BankCode);
            var existingAccount = _accountRepository.GetByAccCode(account.AccCode);

            if (existingAccount != null)
            {
                if (!existingAccount.Equals(account))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Account has already been taken."));
                    return;
                }
            }

            _accountRepository.Update(account);

            if (Commit())
            {
                Bus.RaiseEvent(new AccountUpdatedEvent(Guid.NewGuid(), account.AccCode, account.CusId, account.BankCode));
            }
        }

        public void Dispose()
        {
            _accountRepository.Dispose();
        }
    }
}