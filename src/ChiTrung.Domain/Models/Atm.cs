using System;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Atm : Entity
    {
        public Atm(string atmCode, string bankCode, string atmName)
        {
            AtmCode = atmCode;
            BankCode = bankCode;
            AtmName = atmName;
        }

        // Empty constructor for EF
        protected Atm() { }

        public string AtmCode { get; private set; }

        public string BankCode { get; private set; }

        public string AtmName { get; private set; }
    }
}