using ChiTrung.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiTrung.Domain.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetClientById(int clientId);
        Task<IEnumerable<Client>> GetClientByName(string name);
    }
}