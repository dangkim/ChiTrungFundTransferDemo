using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class AccountAddedEvent : Event
    {
        public AccountAddedEvent(Guid id, string accCode, string cusId, string bankCode)
        {
            AccCode = accCode;
            BankCode = bankCode;
            CusId = cusId;
            AggregateId = id;
        }

        public string AccCode { get; private set; }

        public string BankCode { get; private set; }

        public string CusId { get; private set; }
    }
}