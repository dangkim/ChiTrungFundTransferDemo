using System;
using System.Collections.Generic;
using ChiTrung.Domain.Core.Events;

namespace ChiTrung.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}