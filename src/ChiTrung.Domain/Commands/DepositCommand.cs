using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class DepositCommand : Command
    {
        public int DepCode { get; protected set; }

        public string AccCode { get; protected set; }

        public DateTime TransactionDate { get; protected set; }

        public string CusId { get; protected set; }

        public double Amount { get; protected set; }

        public string WitCode { get; protected set; }
    }
}