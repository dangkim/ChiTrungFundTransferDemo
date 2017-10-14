using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Client : Entity
    {
        public Client(string clientName, string contactMobile, string contactMail, bool isDeleted = false)
        {
            ClientName = clientName;
            ContactMobile = contactMobile;
            ContactMail = contactMail;
            IsDeleted = isDeleted;
        }

        public Client(int clientId, string clientName, string contactMobile, string contactMail, bool isDeleted = false)
        {
            ClientId = clientId;
            ClientName = clientName;
            ContactMobile = contactMobile;
            ContactMail = contactMail;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected Client() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; private set; }

        public string ClientName { get; private set; }

        public string ContactMobile { get; private set; }

        public string ContactMail { get; private set; }

        public bool IsDeleted { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
