using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;

namespace ChiTrung.Application.Interfaces
{
    public interface IWithdrawalAppService : IDisposable
    {
        void WithdrawalAtm(WithdrawalViewModel withdrawalViewModel);
        void FundTransfer(FundTransferViewModel fundTransferViewModel);
        IEnumerable<WithdrawalViewModel> GetAll();
        WithdrawalViewModel GetByWitCode(string witCode);
    }
}
