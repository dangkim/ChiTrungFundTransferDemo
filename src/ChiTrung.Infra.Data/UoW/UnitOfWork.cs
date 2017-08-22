using ChiTrung.Domain.Core.Commands;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using System;
using System.Data.SqlClient;
using System.Transactions;

namespace ChiTrung.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChiTrungContext _context;

        public UnitOfWork(ChiTrungContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            try
            {
                var rowsAffected = _context.SaveChanges();
                return new CommandResponse(rowsAffected > 0);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public CommandResponse CommitTransaction(Withdrawal wit, Deposit dep)
        {
            int rowsAffected = 0;
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.Serializable,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            try
            {
                using (var scope =
                    new TransactionScope(TransactionScopeOption.RequiresNew, options))
                {
                    using (_context)
                    {
                        _context.Withdrawal.Add(wit);
                        _context.SaveChanges();
                        dep.WitCode = wit.WitCode;
                        _context.Deposit.Add(dep);
                        rowsAffected = _context.SaveChanges(); // Save changes to DB
                    }

                    scope.Complete(); // Commit transaction
                }
            }
            catch (Exception e)
            {
                //return new CommandResponse(e);
                throw;
            }
            finally
            {
            }

            //var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
