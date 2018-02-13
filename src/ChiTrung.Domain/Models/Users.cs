using ChiTrung.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace ChiTrung.Domain.Models
{
    public class Users : Entity
    {
        // Empty constructor for EF
        protected Users() { }

        public string MerchantId { get; set; }
        public string MemberId { get; set; }
        public string Nickname { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
