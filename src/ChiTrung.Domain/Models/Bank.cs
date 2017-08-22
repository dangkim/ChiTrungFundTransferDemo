using System;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Bank : Entity
    {
        public Bank(string bandCode, string bankName)
        {
            BankCode = bandCode;
            BankName = bankName;
        }

        // Empty constructor for EF
        protected Bank() { }

        public string BankCode { get; private set; }

        public string BankName { get; private set; }
    }
}