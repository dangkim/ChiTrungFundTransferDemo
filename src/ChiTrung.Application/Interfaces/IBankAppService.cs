using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IBankAppService : IDisposable
    {
        void AddNewBank(BankViewModel bankViewModel);
        IEnumerable<BankViewModel> GetAll();
        BankViewModel GetByBankCode(string bankCode);
        void Update(BankViewModel bankViewModel);
    }
}
