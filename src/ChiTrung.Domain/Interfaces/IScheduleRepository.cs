using ChiTrung.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChiTrung.Domain.Interfaces
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<Schedule> GetScheduleById(int employeeId);
        IEnumerable<Schedule> GetScheduleByEmployeeId(int employeeId);
    }
}