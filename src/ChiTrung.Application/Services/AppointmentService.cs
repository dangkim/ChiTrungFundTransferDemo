using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.Interfaces;
using ChiTrung.Application.ViewModels;
using ChiTrung.Domain.Commands;
using ChiTrung.Domain.Core.Bus;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Infra.Data.Repository.EventSourcing;
using System.Threading.Tasks;

namespace ChiTrung.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public AppointmentService(IMapper mapper,
                                  IAppointmentRepository appointmentRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public Task<int> CheckEmployeeHasOtherAppointments(DateTime desiredTime, string desiredEmpolyee)
        {
            return _appointmentRepository.CheckEmployeeHasOtherAppointments(desiredTime, desiredEmpolyee);
        }

        public Task<IEnumerable<dynamic>> GetAppointmentsOfEmployeeByDesiredTime(DateTime desiredTime, string desiredEmpolyee)
        {
            return _appointmentRepository.GetAppointmentsOfEmployeeByDesiredTime(desiredTime, desiredEmpolyee);
        }

        public Task<IEnumerable<dynamic>> GetEmployeeSchedule(DateTime desiredTime)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<dynamic>> GetOppointmentScheduleByDesiredTime(DateTime desiredTime)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
