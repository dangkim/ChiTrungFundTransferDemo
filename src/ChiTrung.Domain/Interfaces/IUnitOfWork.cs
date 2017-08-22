using System;
using ChiTrung.Domain.Core.Commands;
using ChiTrung.Domain.Models;

namespace ChiTrung.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
        CommandResponse CommitTransaction(Withdrawal wit, Deposit dep);
    }
}
