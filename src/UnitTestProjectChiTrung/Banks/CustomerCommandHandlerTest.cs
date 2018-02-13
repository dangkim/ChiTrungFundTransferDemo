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
    public class CustomerCommandHandlerTest
    {
        public Mock<ICustomerRepository> CustomerRepositoryMock { get; set; }
        public Mock<IMediatorHandler> MediatorMock { get; set; }
        public Mock<IUnitOfWork> MockUnitWork { get; set; }
        public Mock<DomainNotificationHandler> DomainNotificationMock { get; set; }
        //public ChiTrungContext _context;
        public TigersContext _context;
        public CustomerRepository _customerRepository;

        public CustomerCommandHandlerTest()
        {

        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Register Customer New Success")]
        [Trait("Category", "Customer CommandHandler Tests")]
        public void CustomerCommandHandler_AddNewCustomer_ShouldAddWithSuccess()
        {
            // Arrange
            var registerNewCustomerCommand = new RegisterNewCustomerCommand("Tam", "tam@gmail.com", DateTime.Now);
            var customer = new Customer(registerNewCustomerCommand.Id, registerNewCustomerCommand.Name, registerNewCustomerCommand.Email, registerNewCustomerCommand.BirthDate);
            var commandResponse = new CommandResponse(true);

            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            MediatorMock = new Mock<IMediatorHandler>();
            MockUnitWork = new Mock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();

            MockUnitWork.Setup(x => x.Commit()).Returns(commandResponse);

            var customerCommandHandler = new CustomerCommandHandler(CustomerRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);//mocker.Resolve<CustomerCommandHandler>();

            // Act
            customerCommandHandler.Handle(registerNewCustomerCommand);

            // Assert
            CustomerRepositoryMock.Verify(r => r.Add(customer), Times.Once);
            MockUnitWork.Verify(m => m.Commit(), Times.Once);
        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Register Customer New Without Name")]
        [Trait("Category", "Customer CommandHandler Tests")]
        public void CustomerCommandHandler_AddNewCustomer_WithoutName()
        {
            // Arrange
            var registerNewCustomerCommand = new RegisterNewCustomerCommand("", "tam@gmail.com", DateTime.Now);
            var bank = new Customer(registerNewCustomerCommand.Id, registerNewCustomerCommand.Name, registerNewCustomerCommand.Email, registerNewCustomerCommand.BirthDate);
            var commandResponse = new CommandResponse(true);

            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            MediatorMock = new Mock<IMediatorHandler>();
            MockUnitWork = new Mock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();

            MockUnitWork.Setup(x => x.Commit()).Returns(commandResponse);

            var customerCommandHandler = new CustomerCommandHandler(CustomerRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);//mocker.Resolve<CustomerCommandHandler>();

            // Act
            customerCommandHandler.Handle(registerNewCustomerCommand);

            // Assert
            CustomerRepositoryMock.Verify(r => r.Add(bank), Times.Never);
            MockUnitWork.Verify(m => m.Commit(), Times.Never);
        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Register Customer New Without Email")]
        [Trait("Category", "Customer CommandHandler Tests")]
        public void CustomerCommandHandler_AddNewCustomer_WithoutEmail()
        {
            // Arrange
            var registerNewCustomerCommand = new RegisterNewCustomerCommand("Tam", "", DateTime.Now);
            var customer = new Customer(registerNewCustomerCommand.Id, registerNewCustomerCommand.Name, registerNewCustomerCommand.Email, registerNewCustomerCommand.BirthDate);
            var commandResponse = new CommandResponse(true);

            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            MediatorMock = new Mock<IMediatorHandler>();
            MockUnitWork = new Mock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();

            MockUnitWork.Setup(x => x.Commit()).Returns(commandResponse);

            var customerCommandHandler = new CustomerCommandHandler(CustomerRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);//mocker.Resolve<CustomerCommandHandler>();

            // Act
            customerCommandHandler.Handle(registerNewCustomerCommand);

            // Assert
            CustomerRepositoryMock.Verify(r => r.Add(customer), Times.Never);
            MockUnitWork.Verify(m => m.Commit(), Times.Never);
        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Register Customer New Without Birthday")]
        [Trait("Category", "Customer CommandHandler Tests")]
        public void CustomerCommandHandler_AddNewCustomer_WithoutDate()
        {
            // Arrange
            var registerNewCustomerCommand = new RegisterNewCustomerCommand("Tam", "tam@gmail.com", DateTime.MinValue);
            var customer = new Customer(registerNewCustomerCommand.Id, registerNewCustomerCommand.Name, registerNewCustomerCommand.Email, registerNewCustomerCommand.BirthDate);
            var commandResponse = new CommandResponse(true);

            CustomerRepositoryMock = new Mock<ICustomerRepository>();
            MediatorMock = new Mock<IMediatorHandler>();
            MockUnitWork = new Mock<IUnitOfWork>();
            DomainNotificationMock = new Mock<DomainNotificationHandler>();

            MockUnitWork.Setup(x => x.Commit()).Returns(commandResponse);

            var customerCommandHandler = new CustomerCommandHandler(CustomerRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);//mocker.Resolve<CustomerCommandHandler>();

            // Act
            customerCommandHandler.Handle(registerNewCustomerCommand);

            // Assert
            CustomerRepositoryMock.Verify(r => r.Add(customer), Times.Never);
            MockUnitWork.Verify(m => m.Commit(), Times.Never);
        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Check Existing Customer Name")]
        [Trait("Category", "Customer CommandHandler Tests")]
        public void CustomerCommandHandler_AddNewCustomer_ExistingUserName()
        {
            // Arrange
            var registerNewCustomerCommand = new RegisterNewCustomerCommand("Kevin", "kevin1@gmail.com", DateTime.Now);
            var customer = new Customer(registerNewCustomerCommand.Id, registerNewCustomerCommand.Name, registerNewCustomerCommand.Email, registerNewCustomerCommand.BirthDate);
            var commandResponse = new CommandResponse(false);

            MockUnitWork.Setup(x => x.Commit()).Returns(commandResponse);

            var customerCommandHandler = new CustomerCommandHandler(CustomerRepositoryMock.Object, MockUnitWork.Object, MediatorMock.Object, DomainNotificationMock.Object);//mocker.Resolve<CustomerCommandHandler>();

            // Act
            customerCommandHandler.Handle(registerNewCustomerCommand);

            // Assert
            CustomerRepositoryMock.Verify(r => r.Add(customer), Times.Never);
            MockUnitWork.Verify(m => m.Commit(), Times.Never);
        }

        // AAA == Arrange, Act, Assert
        [Fact(DisplayName = "Check UniqueConstraints Customer")]
        [Trait("Category", "Customer Repository Tests")]
        public void CustomerCommandHandler_AddNewCustomer_UniqueConstraints()
        {
            // Arrange
            //_context = new ChiTrungContext();
            _context = new TigersContext();
            _customerRepository = new CustomerRepository(_context);
            var registerNewCustomerCommand = new RegisterNewCustomerCommand("Kevin", "kevin1@gmail.com", DateTime.Now);
            var customer = new Customer(registerNewCustomerCommand.Id, registerNewCustomerCommand.Name, registerNewCustomerCommand.Email, registerNewCustomerCommand.BirthDate);

            // Act
            _customerRepository.Add(customer);
            Microsoft.EntityFrameworkCore.DbUpdateException ex = Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => _context.SaveChanges());

            // Assert
            Assert.Contains("The duplicate key value", ex.InnerException.Message);
        }
    }
}
