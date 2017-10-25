using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class AccountCommand : Command
    {
        public string AccCode { get; protected set; }

        public string BankCode { get; protected set; }

        public string CusId { get; protected set; }
    }
}