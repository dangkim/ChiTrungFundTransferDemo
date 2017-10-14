using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class ClientUpdatedEvent : Event
    {
        public ClientUpdatedEvent(int clientId, string clientName, string contactMobile, string contactMail)
        {
            ClientId = clientId;
            ClientName = clientName;
            ContactMobile = contactMobile;
            ContactMail = contactMail;
            AggregateId = Guid.NewGuid();
        }

        public int ClientId { get; private set; }

        public string ClientName { get; private set; }

        public string ContactMobile { get; private set; }

        public string ContactMail { get; private set; }
    }
}