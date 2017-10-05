using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IScheduleService : IDisposable
    {
        void AddNewAccount(AccountViewModel accountViewModel);
        IEnumerable<AccountViewModel> GetAll();
        AccountViewModel GetByScheduleId(string id);
        void Update(AccountViewModel accountViewModel);
    }
}
