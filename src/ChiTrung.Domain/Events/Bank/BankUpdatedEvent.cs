using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class BankUpdatedEvent : Event
    {
        public BankUpdatedEvent(Guid id, string bankCode, string bankName)
        {
            BankCode = bankCode;
            BankName = bankName;
            AggregateId = id;
        }
        public string BankCode { get; private set; }

        public string BankName { get; private set; }
    }
}