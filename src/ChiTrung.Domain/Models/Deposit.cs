using System;
using ChiTrung.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChiTrung.Domain.Models
{
    public class Deposit : Entity
    {
        public Deposit(string accCode
            , DateTime tDate
            , string cusId
            , double amount
            , string witCode)
        {
            AccCode = accCode;
            TransactionDate = tDate;
            CusId = cusId;
            Amount = amount;
            WitCode = witCode;
        }

        // Empty constructor for EF
        protected Deposit() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepCode { get; private set; }

        public string AccCode { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public string CusId { get; private set; }

        public double Amount { get; private set; }

        public string WitCode { get; set; }
    }
}