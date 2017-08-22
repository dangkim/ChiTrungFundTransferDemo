using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IWithdrawalRepository : IRepository<Withdrawal>
    {
        Withdrawal GetByWitCode(string witCode);
    }
}