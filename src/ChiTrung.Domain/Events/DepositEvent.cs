using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class DepositEvent : Event
    {
        public DepositEvent(Guid id, int depCode, string accCode
            , DateTime tDate
            , string cusId
            , double amount
            , string witCode)
        {
            DepCode = depCode;
            AccCode = accCode;
            TransactionDate = tDate;
            CusId = cusId;
            Amount = amount;
            WitCode = witCode;
            AggregateId = id;
        }

        public int DepCode { get; private set; }

        public string AccCode { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public string CusId { get; private set; }

        public double Amount { get; private set; }

        public string WitCode { get; private set; }
    }
}