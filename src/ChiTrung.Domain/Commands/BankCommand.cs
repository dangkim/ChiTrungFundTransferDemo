using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class BankCommand : Command
    {
        public string BankCode { get; protected set; }

        public string BankName { get; protected set; }
    }
}