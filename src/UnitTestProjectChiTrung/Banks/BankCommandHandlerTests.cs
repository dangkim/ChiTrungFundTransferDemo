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
using Xunit;

namespace ChiTrung.Infra.Test.Banks
{
    public class BankCommandHandlerTests
    {
        public Mock<IBankRepository> BankRepositoryMock { get; set; }
        public Mock<IMediatorHandler> MediatorMock { get; set; }
        public Mock<IUnitOfWork> MockUnitWork { get; set; }
        public Mock<DomainNotificationHandler> DomainNotificationMock { get; set; }
        public ChiTrungContext _context;
        public BankRepository _bankRepository;

        public BankCommandHandlerTests()
        {

        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Add Bank New Success")]
        [Trait("Category", "Bank CommandHandler Tests")]
        public void BankCommandHandler_AddNewBank_ShouldAddWithSuccess()
        {
            // Arrange
            var addNewBankCommand = new AddNewBankCommand("BD", "Bank D");
            var bank = new Bank(addNewBankCommand.BankCode, addNewBankCommand.BankName);

            //var mocker = new AutoMoqer();
            var commandResponse = new CommandResponse(true);
            //mocker.Create<BankCommandHandler>();

            BankRepositoryMock = new Mock<IBankRepository>();//mocker.GetMock<IBankRepository>();
            MediatorMock = new Mock<IMediatorHandler>();//mocker.GetMock<IMediator>();
            MockUnitWork = new Mock<IUnitOfWork>();//mocker.GetMock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();//mocker.GetMock<INotificationHandler<DomainNotification>>();

            MockUnitWork.Setup(x => x.Commit()).Returns(commandResponse);

            var bankCommandHandler = new BankCommandHandler(BankRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);//mocker.Resolve<BankCommandHandler>();

            // Act
            bankCommandHandler.Handle(addNewBankCommand);

            // Assert
            BankRepositoryMock.Verify(r => r.Add(bank), Times.Once);
            MockUnitWork.Verify(m => m.Commit(), Times.Once);

        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Add Bank Without BankCode Fail")]
        [Trait("Category", "Bank CommandHandler Tests")]
        public void BankCommandHandler_AddNewBank_WithoutBankCode()
        {
            // Arrange
            var addNewBankCommand = new AddNewBankCommand("", "Bank D");
            var bank = new Bank(addNewBankCommand.BankCode, addNewBankCommand.BankName);

            BankRepositoryMock = new Mock<IBankRepository>();
            MediatorMock = new Mock<IMediatorHandler>();
            MockUnitWork = new Mock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();

            var bankCommandHandler = new BankCommandHandler(BankRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);

            // Act
            bankCommandHandler.Handle(addNewBankCommand);

            // Assert
            BankRepositoryMock.Verify(r => r.Add(bank), Times.Never);
            MockUnitWork.Verify(m => m.Commit(), Times.Never);

        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Add Bank Without BankName Fail")]
        [Trait("Category", "Bank CommandHandler Tests")]
        public void BankCommandHandler_AddNewBank_WithoutBankName()
        {
            // Arrange
            var addNewBankCommand = new AddNewBankCommand("BD", "");
            var bank = new Bank(addNewBankCommand.BankCode, addNewBankCommand.BankName);

            BankRepositoryMock = new Mock<IBankRepository>();
            MediatorMock = new Mock<IMediatorHandler>();
            MockUnitWork = new Mock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();

            var bankCommandHandler = new BankCommandHandler(BankRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);

            // Act
            bankCommandHandler.Handle(addNewBankCommand);

            // Assert
            BankRepositoryMock.Verify(r => r.Add(bank), Times.Never);
            MockUnitWork.Verify(m => m.Commit(), Times.Never);

        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Check existing BankCode")]
        [Trait("Category", "Bank CommandHandler Tests")]
        public void BankCommandHandler_AddNewBank_ExistingBankCode()
        {
            // Arrange
            _context = new ChiTrungContext();
            _bankRepository = new BankRepository(_context);

            // Act
            var result = _bankRepository.GetByBankCode("BA");

            // Assert
            Assert.NotNull(result);

        }
    }
}

