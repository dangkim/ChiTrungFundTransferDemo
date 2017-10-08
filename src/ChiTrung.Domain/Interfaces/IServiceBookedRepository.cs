using ChiTrung.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiTrung.Domain.Interfaces
{
    public interface IServiceBookedRepository : IRepository<ServiceBooked>
    {
        Task<ServiceBooked> GetServiceBookedById(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeeByName(string name);
    }
}