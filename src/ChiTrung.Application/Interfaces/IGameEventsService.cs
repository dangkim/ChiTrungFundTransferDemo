using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IGameEventsService : IDisposable
    {
        IEnumerable<GameEventsViewModel> GetAll();
        GameEventsViewModel GetById(long id);
        GameEventsViewModel GetByTransactionId(Guid id);
        //IList<GameEventsViewModel> GetAllHistory(long id);
    }
}
