using System;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Core.Notifications;
using ChiTrung.Domain.Events;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChiTrung.Domain.CommandHandlers
{
    public class EmployeeCommandHandler : CommandHandler,
        INotificationHandler<RegisterNewEmployeeCommand>,
        INotificationHandler<UpdateEmployeeCommand>,
        INotificationHandler<RemoveEmployeeCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMediatorHandler Bus;

        public EmployeeCommandHandler(IEmployeeRepository employeeRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _employeeRepository = employeeRepository;
            Bus = bus;
        }

        public void Handle(RegisterNewEmployeeCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var employee = new Employee(message.FirstName, message.LastName);

            try
            {
                _employeeRepository.Add(employee);
            }
            catch (DbUpdateException)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The employee has already been taken."));
                throw;
            }

            if (Commit())
            {
                Bus.RaiseEvent(new EmployeeRegisteredEvent(employee.EmployeeId, employee.FirstName, employee.LastName));
            }
        }

        public void Handle(UpdateEmployeeCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var employee = new Employee(message.EmployeeId, message.FirstName, message.LastName);

            try
            {
                _employeeRepository.Update(employee);
            }
            catch (DbUpdateException)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The employee has already been taken."));
                throw;
            }

            if (Commit())
            {
                Bus.RaiseEvent(new EmployeeUpdatedEvent(employee.EmployeeId, employee.FirstName, employee.LastName));
            }
        }

        public void Handle(RemoveEmployeeCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var employee = new Employee(message.EmployeeId, message.FirstName, message.LastName, true);

            try
            {
                _employeeRepository.Update(employee);
            }
            catch (DbUpdateException)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Employee has already been taken."));
                throw;
            }

            if (Commit())
            {
                Bus.RaiseEvent(new EmployeeUpdatedEvent(employee.EmployeeId, employee.FirstName, employee.LastName));
            }
        }

        public void Dispose()
        {
            _employeeRepository.Dispose();
        }
    }
}