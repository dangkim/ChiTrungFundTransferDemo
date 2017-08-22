using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Infra.Data.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ChiTrungContext context)
            : base(context)
        {

        }

        public Account GetByAccCode(string accCode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a => a.AccCode == accCode);
        }
    }
}
