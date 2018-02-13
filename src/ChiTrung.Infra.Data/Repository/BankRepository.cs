using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Infra.Data.Repository
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        public BankRepository(TigersContext context)
            : base(context)
        {

        }

        public Bank GetByBankCode(string bankCode)
        {
            return DbSet.AsNoTracking().FirstOrDefault(b => b.BankCode == bankCode);
        }
    }
}
