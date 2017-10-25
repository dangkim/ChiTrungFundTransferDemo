using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChiTrung.Domain.Core.Models;

namespace ChiTrung.Domain.Models
{
    public class Employee : Entity
    {
        public Employee(string firstName, string lastName, bool isDeleted = false)
        {
            FirstName = firstName;
            LastName = lastName;
            IsDeleted = isDeleted;
        }

        public Employee(int employeeId, string firstName, string lastName, bool isDeleted = false)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            IsDeleted = isDeleted;
        }

        // Empty constructor for EF
        protected Employee() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public bool IsDeleted { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
