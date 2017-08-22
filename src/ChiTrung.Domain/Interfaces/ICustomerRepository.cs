using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByName(string name);
        Customer GetByEmail(string email);
    }
}