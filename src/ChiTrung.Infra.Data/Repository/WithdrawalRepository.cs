using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Infra.Data.Repository
{
    public class WithdrawalRepository : Repository<Withdrawal>, IWithdrawalRepository
    {
        public WithdrawalRepository(ChiTrungContext context)
            : base(context)
        {

        }

        public Withdrawal GetByWitCode(string witCode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(d => d.WitCode == witCode);
        }
    }
}
