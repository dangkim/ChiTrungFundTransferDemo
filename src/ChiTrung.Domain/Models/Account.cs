using System;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Account : Entity
    {
        public Account(string accCode, string cusId, string bankCode)
        {
            AccCode = accCode;
            CusId = cusId;
            BankCode = bankCode;
        }

        // Empty constructor for EF
        protected Account() { }

        public string AccCode { get; private set; }

        public string BankCode { get; private set; }

        public string CusId { get; private set; }
    }
}