using System;
using ChiTrung.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChiTrung.Domain.Models
{
    public class Withdrawal : Entity
    {
        public Withdrawal(string witCode, string accCode, DateTime tDate, double amount, string atmCode)
        {
            WitCode = witCode;
            AccCode = accCode;
            TransactionDate = tDate;
            Amount = amount;
            AtmCode = atmCode;
        }

        // Empty constructor for EF
        protected Withdrawal() { }

        public string WitCode { get; private set; }

        public string AccCode { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public double Amount { get; private set; }

        public string AtmCode { get; private set; }

    }
}