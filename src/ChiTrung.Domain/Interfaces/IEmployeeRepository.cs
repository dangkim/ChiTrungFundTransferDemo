using ChiTrung.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiTrung.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetEmployeeById(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeeByName(string name);
    }
}