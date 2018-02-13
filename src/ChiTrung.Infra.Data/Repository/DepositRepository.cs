using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Infra.Data.Repository
{
    public class DepositRepository : Repository<Deposit>, IDepositRepository
    {
        public DepositRepository(TigersContext context)
            : base(context)
        {

        }

        public Deposit GetByDepCode(int depCode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(d => d.DepCode == depCode);
        }
    }
}
