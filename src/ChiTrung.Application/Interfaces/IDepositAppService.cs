using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IDepositAppService : IDisposable
    {
        void DepositMoney(DepositViewModel depositViewModel);
        IEnumerable<DepositViewModel> GetAll();
        DepositViewModel GetByDepCode(int depCode);
    }
}
