using System;
using System.Collections.Generic;
using ChiTrung.Application.EventSourcedNormalizers;
using ChiTrung.Application.ViewModels;
using System.Threading.Tasks;

namespace ChiTrung.Application.Interfaces
{
    public interface IAppointmentService : IDisposable
    {
        Task<IEnumerable<dynamic>> GetEmployeeSchedule(DateTime desiredTime);
        Task<int> CheckEmployeeHasOtherAppointments(DateTime desiredTime, string desiredEmpolyee);
        Task<IEnumerable<dynamic>> GetOppointmentScheduleByDesiredTime(DateTime desiredTime);
        Task<IEnumerable<dynamic>> GetAppointmentsOfEmployeeByDesiredTime(DateTime desiredTime, string desiredEmpolyee);
    }
}
