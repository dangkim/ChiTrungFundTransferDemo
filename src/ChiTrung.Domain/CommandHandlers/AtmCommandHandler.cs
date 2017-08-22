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
    public class AtmCommandHandler : CommandHandler,
        INotificationHandler<AddNewAtmCommand>,
        INotificationHandler<UpdateAtmCommand>
    {
        private readonly IAtmRepository _atmRepository;
        private readonly IMediatorHandler Bus;

        public AtmCommandHandler(IAtmRepository atmRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _atmRepository = atmRepository;
            Bus = bus;
        }

        public void Handle(AddNewAtmCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var atm = new Atm(message.AtmCode, message.BankCode, message.AtmName);

            if (_atmRepository.GetByAtmCode(atm.AtmCode) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The code of the Atm has already been taken."));
                return;
            }

            _atmRepository.Add(atm);

            if (Commit())
            {
                Bus.RaiseEvent(new AtmAddedEvent(Guid.NewGuid(), atm.AtmCode, atm.BankCode, atm.AtmName));
            }
        }

        public void Handle(UpdateAtmCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var atm = new Atm(message.AtmCode, message.BankCode, message.AtmName);
            var existingAtm = _atmRepository.GetByAtmCode(atm.AtmCode);

            if (existingAtm != null)
            {
                if (!existingAtm.Equals(atm))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Atm has already been taken."));
                    return;
                }
            }

            _atmRepository.Update(atm);

            if (Commit())
            {
                Bus.RaiseEvent(new AtmUpdatedEvent(Guid.NewGuid(), atm.AtmCode, atm.BankCode, atm.AtmName));
            }
        }

        public void Dispose()
        {
            _atmRepository.Dispose();
        }
    }
}