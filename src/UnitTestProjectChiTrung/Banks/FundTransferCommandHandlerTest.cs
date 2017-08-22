using AutoMoq;
using ChiTrung.Domain.CommandHandlers;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Core.Commands;
using ChiTrung.Domain.Core.Notifications;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using ChiTrung.Infra.Data.Repository;
using MediatR;
using Moq;
using System;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace ChiTrung.Infra.Test.Customers
{
    public class FundTransferCommandHandlerTest
    {
        public Mock<IWithdrawalRepository> WithdrawalRepositoryMock { get; set; }
        public Mock<IMediatorHandler> MediatorMock { get; set; }
        public Mock<IUnitOfWork> MockUnitWork { get; set; }
        public Mock<DomainNotificationHandler> DomainNotificationMock { get; set; }
        public ChiTrungContext _context;
        public WithdrawalRepository _withdrawalRepository;
        public DepositRepository _depositRepository;
        public AccountRepository _accountRepository;

        public FundTransferCommandHandlerTest()
        {

        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Check Existing WitCode")]
        [Trait("Category", "Customer CommandHandler Tests")]
        public void WithDrawalCommandHandler_Funtransfer_ExistingWitCode()
        {
            // Arrange
            var cusId = "34DA9564-F692-4E0B-B278-70EE9C0FCE96";
            var witCode = "297fba37-4c11-4315-8a8f-02f0d5351925";
            var fundTransferCommand = new FundTransferCommand(witCode, "8123", "3212", DateTime.Now, cusId, 450, null);
            var withdrawal = new Withdrawal(fundTransferCommand.WitCode, fundTransferCommand.AccCode, fundTransferCommand.TransactionDate, fundTransferCommand.Amount, fundTransferCommand.AtmCode);
            _context = new ChiTrungContext();
            _withdrawalRepository = new WithdrawalRepository(_context);

            // Act
            var result = _withdrawalRepository.GetByWitCode(fundTransferCommand.WitCode);

            // Assert
            Assert.NotNull(result);
        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Fund Transfer Success")]
        [Trait("Category", "Funtransfer CommandHandler Tests")]
        public void FuntransferCommandHandler_ShouldTransferWithSuccess()
        {
            // Arrange
            var cusId = "34DA9564-F692-4E0B-B278-70EE9C0FCE96";
            var fundTransferCommand = new FundTransferCommand(Guid.NewGuid().ToString(), "8123", "3212", DateTime.Now, cusId, 450, null);
            var withdrawal = new Withdrawal(fundTransferCommand.WitCode, fundTransferCommand.AccCode, fundTransferCommand.TransactionDate, fundTransferCommand.Amount, fundTransferCommand.AtmCode);
            var deposit = new Deposit(fundTransferCommand.ToAccCode, fundTransferCommand.TransactionDate, fundTransferCommand.CusId, fundTransferCommand.Amount, fundTransferCommand.WitCode);

            _context = new ChiTrungContext();
            _withdrawalRepository = new WithdrawalRepository(_context);
            _depositRepository = new DepositRepository(_context);
            _accountRepository = new AccountRepository(_context);

            // Act
            _withdrawalRepository.Add(withdrawal);
            _depositRepository.Add(deposit);
            _context.SaveChanges();
            var account = _accountRepository.GetByAccCode(fundTransferCommand.AccCode);

            // Assert
            Assert.Equal(withdrawal.Amount, deposit.Amount);
            Assert.Equal(deposit.WitCode, withdrawal.WitCode);
            Assert.Equal(deposit.CusId.ToLower(), account.CusId.ToLower());
            Assert.Null(withdrawal.AtmCode);
        }
    }
}
