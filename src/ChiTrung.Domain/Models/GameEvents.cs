using ChiTrung.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChiTrung.Domain.Models
{
    public class GameEvents: Entity
    {
        // Empty constructor for EF
        protected GameEvents() { }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }

        public Guid TransactionId { get; private set; }
        public string MerchantId { get; private set; }
        public string MemberId { get; private set; }
        public string GameId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Event { get; private set; }
    }
}
