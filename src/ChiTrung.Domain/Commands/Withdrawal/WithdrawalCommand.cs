using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class WithdrawalCommand : Command
    {
        public string WitCode { get; protected set; }

        public string AccCode { get; protected set; }

        public string ToAccCode { get; protected set; }

        public DateTime TransactionDate { get; protected set; }

        public string CusId { get; protected set; }

        public double Amount { get; protected set; }

        public string AtmCode { get; protected set; }
    }
}