using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class AtmUpdatedEvent : Event
    {
        public AtmUpdatedEvent(Guid id, string atmCode, string bankCode, string atmName)
        {
            AtmCode = atmCode;
            BankCode = bankCode;
            AtmName = atmName;
            AggregateId = id;
        }

        public string AtmCode { get; private set; }

        public string BankCode { get; private set; }

        public string AtmName { get; private set; }
    }
}