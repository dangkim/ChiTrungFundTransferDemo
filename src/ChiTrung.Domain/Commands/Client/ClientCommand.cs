using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class ClientCommand : Command
    {
        public int ClientId { get; protected set; }

        public string ClientName { get; protected set; }

        public string ContactMobile { get; protected set; }

        public string ContactMail { get; protected set; }
    }
}