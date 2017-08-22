using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByAccCode(string accCode);
    }
}