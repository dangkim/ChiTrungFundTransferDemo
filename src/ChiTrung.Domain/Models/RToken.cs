using System;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class RToken : Entity
    {
        public RToken(Guid id, string clientId, string refreshToken, bool isStop)
        {
            //Id = id;
            ClientId = clientId;
            RefreshToken = refreshToken;
            IsStop = isStop;
        }

        // Empty constructor for EF
        protected RToken() { }

        public string ClientId { get; protected set; }

        public string RefreshToken { get; protected set; }

        public bool IsStop { get; protected set; }
    }
}