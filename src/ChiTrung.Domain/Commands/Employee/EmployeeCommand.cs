using System;
using ChiTrung.Domain.Core.Commands;

namespace ChiTrung.Domain.Commands
{
    public abstract class EmployeeCommand : Command
    {
        public int EmployeeId { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public bool IsDeleted { get; protected set; }
    }
}