using System;
using ChiTrung.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChiTrung.Domain.Models
{
    public class Appointment : Entity
    {
        public Appointment(DateTime dateCreated
            , int employeeCreated
            , int clientId
            , int employeeId
            , string contactMobile
            , DateTime startTime
            , DateTime endTimeExpected
            , DateTime endTime
            , decimal priceExpected
            , decimal priceFull
            , decimal discount
            , decimal priceFinal
            , bool cancelled
            , string cancellationReason
            , bool isDeleted = false
            )
        {
            DateCreated = dateCreated;
            EmployeeCreated = employeeCreated;
            ClientId = clientId;
            EmployeeId = employeeId;
            ContactMobile = contactMobile;
            StartTime = startTime;
            EndTimeExpected = endTimeExpected;
            EndTime = endTime;
            PriceExpected = priceExpected;
            PriceFull = priceFull;
            Discount = discount;
            PriceFinal = priceFinal;
            Cancelled = cancelled;
            CancellationReason = cancellationReason;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected Appointment() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; private set; }

        public DateTime DateCreated { get; private set; }

        public int EmployeeCreated { get; private set; }

        public int ClientId { get; private set; }

        public int EmployeeId { get; private set; }

        public string ClientName { get; private set; }

        public string ContactMobile { get; private set; }

        public DateTime StartTime { get; private set; }

        public DateTime EndTimeExpected { get; private set; }

        public DateTime EndTime { get; private set; }

        public decimal PriceExpected { get; private set; }

        public decimal PriceFull { get; private set; }

        public decimal Discount { get; private set; }

        public decimal PriceFinal { get; private set; }

        public bool Cancelled { get; private set; }

        public string CancellationReason { get; private set; }

        public bool IsDeleted { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}