using System;
using System.Linq;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Infra.Data.Repository
{
    public class GameEventsRepository : Repository<GameEvents>, IGameEventsRepository
    {
        public GameEventsRepository(TigersContext context)
            : base(context)
        {

        }

        public GameEvents GetByTransactionId(Guid transactionId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(b => b.TransactionId == transactionId);
        }
    }
}
