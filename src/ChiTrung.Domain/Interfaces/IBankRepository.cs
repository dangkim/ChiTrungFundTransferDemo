using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IBankRepository : IRepository<Bank>
    {
        Bank GetByBankCode(string bankCode);
    }
}