using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class WithdrawalEvent : Event
    {
        public WithdrawalEvent(Guid id, string witCode, string accCode, DateTime tDate, double amount, string atmCode)
        {
            WitCode = witCode;
            AccCode = accCode;
            TransactionDate = tDate;
            Amount = amount;
            AtmCode = atmCode;
            AggregateId = id;
        }

        public string WitCode { get; private set; }

        public string AccCode { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public double Amount { get; private set; }

        public string AtmCode { get; private set; }
    }
}