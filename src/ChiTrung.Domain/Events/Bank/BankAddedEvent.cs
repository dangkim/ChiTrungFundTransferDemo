using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class BankAddedEvent : Event
    {
        public BankAddedEvent(Guid id, string bankCode, string bankName)
        {
            BankCode = bankCode;
            BankName = bankName;
            AggregateId = id;
        }

        public string BankCode { get; private set; }

        public string BankName { get; private set; }
    }
}