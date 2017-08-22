using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class AtmCommand : Command
    {
        public string AtmCode { get; protected set; }

        public string BankCode { get; protected set; }

        public string AtmName { get; protected set; }
    }
}