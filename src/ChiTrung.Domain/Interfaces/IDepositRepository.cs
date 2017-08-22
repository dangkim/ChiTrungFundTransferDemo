using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IDepositRepository : IRepository<Deposit>
    {
        Deposit GetByDepCode(int depCode);
    }
}