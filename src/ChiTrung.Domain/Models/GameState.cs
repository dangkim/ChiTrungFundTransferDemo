using ChiTrung.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ChiTrung.Domain.Models
{
    public class GameState : Entity
    {
        // Empty constructor for EF
        protected GameState() { }

        public string MerchantId { get; set; }
        public string MemberId { get; set; }
        public string GameId { get; set; }
        public string Payload { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
