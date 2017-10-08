using ChiTrung.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiTrung.Domain.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<Service> GetServiceById(int serviceId);
        Task<IEnumerable<Service>> GetServiceByName(string name);
    }
}