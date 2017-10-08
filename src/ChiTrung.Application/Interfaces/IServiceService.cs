using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IServiceService : IDisposable
    {
        void AddNewAccount(AccountViewModel accountViewModel);
        IEnumerable<AccountViewModel> GetAll();
        AccountViewModel GetByAccCode(string accCode);
        void Update(AccountViewModel accountViewModel);
    }
}
