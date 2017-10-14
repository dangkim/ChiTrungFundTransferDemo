using System;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Core.Notifications;
using ChiTrung.Domain.Events;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Domain.CommandHandlers
{
    public class ClientCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewClientCommand>,
        INotificationHandler<UpdateClientCommand>,
        INotificationHandler<RemoveClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMediatorHandler Bus;

        public ClientCommandHandler(IClientRepository clientRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _clientRepository = clientRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(message.ClientName, message.ContactMobile, message.ContactMail);

            try
            {
                _clientRepository.Add(client);
            }
            catch (DbUpdateException)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The client has already been taken."));
                throw;
            }

            if (Commit())
            {
                Bus.RaiseEvent(new ClientRegisteredEvent(client.ClientId, client.ClientName, client.ContactMobile, client.ContactMail));
            }
        }

        public void Handle(UpdateClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(message.ClientId, message.ClientName, message.ContactMobile, message.ContactMail);

            try
            {
                _clientRepository.Update(client);
            }
            catch (DbUpdateException)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The client has already been taken."));
                throw;
            }

            if (Commit())
            {
                Bus.RaiseEvent(new ClientUpdatedEvent(client.ClientId, client.ClientName, client.ContactMobile, client.ContactMail));
            }
        }

        public void Handle(RemoveClientCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var client = new Client(message.ClientId, message.ClientName, message.ContactMobile, message.ContactMail, true);

            try
            {
                _clientRepository.Update(client);
            }
            catch (DbUpdateException)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The client has already been taken."));
                throw;
            }

            if (Commit())
            {
                Bus.RaiseEvent(new ClientUpdatedEvent(client.ClientId, client.ClientName, client.ContactMobile, client.ContactMail));
            }
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}