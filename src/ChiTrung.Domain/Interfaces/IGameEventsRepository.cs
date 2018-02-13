using System;
using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IGameEventsRepository : IRepository<GameEvents>
    {
        //GameEvents GetByTransactionId(Guid txnId);
        //GameEvents GetById(long id);
    }
}