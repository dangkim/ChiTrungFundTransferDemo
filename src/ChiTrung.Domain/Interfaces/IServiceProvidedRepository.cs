using ChiTrung.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiTrung.Domain.Interfaces
{
    public interface IServiceProvidedRepository : IRepository<ServiceProvided>
    {
        Task<ServiceProvided> GetServiceProvidedById(int employeeId);
        Task<IEnumerable<Employee>> GetEmployeeByName(string name);
    }
}