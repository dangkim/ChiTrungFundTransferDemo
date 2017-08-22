using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class AtmAddedEvent : Event
    {
        public AtmAddedEvent(Guid id, string atmCode, string bankCode, string atmName)
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