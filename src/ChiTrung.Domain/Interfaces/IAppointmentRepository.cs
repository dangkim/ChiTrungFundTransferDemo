using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChiTrung.Domain.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<dynamic>> GetEmployeeSchedule(DateTime desiredTime);
        Task<int> CheckEmployeeHasOtherAppointments(DateTime desiredTime, string desiredEmpolyee);
        Task<IEnumerable<dynamic>> GetOppointmentScheduleByDesiredTime(DateTime desiredTime);
        Task<IEnumerable<dynamic>> GetAppointmentsOfEmployeeByDesiredTime(DateTime desiredTime, string desiredEmpolyee);
    }
}