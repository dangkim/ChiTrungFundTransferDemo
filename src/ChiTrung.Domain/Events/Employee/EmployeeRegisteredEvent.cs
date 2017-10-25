using System;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Domain.Events
{
    public class EmployeeRegisteredEvent : Event
    {
        public EmployeeRegisteredEvent(int employeeId, string firstName, string lastName)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            AggregateId = Guid.NewGuid();
        }

        public int EmployeeId { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public bool IsDeleted { get; private set; }
    }
}