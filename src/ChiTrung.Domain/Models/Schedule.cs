using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Schedule : Entity
    {
        public Schedule(int employeeId, DateTime from, DateTime to, bool isDeleted = false)
        {
            EmployeeId = employeeId;
            From = from;
            To = to;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected Schedule() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; private set; }

        public int EmployeeId { get; private set; }

        public DateTime From { get; private set; }

        public DateTime To { get; private set; }

        public bool IsDeleted { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
