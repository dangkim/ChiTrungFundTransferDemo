using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data.SqlClient;
using System;
using Microsoft.Extensions.Configuration;

namespace ChiTrung.Infra.Data.Repository
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private string _connectionString = string.Empty;
        private readonly IConfiguration _config;

        public ScheduleRepository(ChiTrungContext context, IConfiguration config)
            : base(context)
        {
            this._config = config;
            _connectionString = this._config.GetConnectionString("DefaultConnection");
        }

        public async Task<Schedule> GetScheduleById(int scheduleId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.ScheduleId == scheduleId && a.IsDeleted == false);
        }

        public IEnumerable<Schedule> GetScheduleByEmployeeId(int employeeId)
        {
            return DbSet.AsNoTracking().Where(a => a.EmployeeId == employeeId && a.IsDeleted == false);
        }
    }
}
