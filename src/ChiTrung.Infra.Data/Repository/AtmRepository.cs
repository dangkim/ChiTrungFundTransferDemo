using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Infra.Data.Repository
{
    public class AtmRepository : Repository<Atm>, IAtmRepository
    {
        public AtmRepository(ChiTrungContext context)
            : base(context)
        {

        }

        public Atm GetByAtmCode(string atmCode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(a => a.AtmCode == atmCode);
        }
    }
}
