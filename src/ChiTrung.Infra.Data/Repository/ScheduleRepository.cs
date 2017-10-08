using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiTrung.Domain.Interfaces;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.Extensions.Options;
using ChiTrung.Domain.Options;
using System.Data.SqlClient;
using System;

namespace ChiTrung.Infra.Data.Repository
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private readonly DatabaseOptions _options;
        private string _connectionString = string.Empty;

        public ScheduleRepository(ChiTrungContext context, IOptions<DatabaseOptions> databaseOptions)
            : base(context)
        {
            _options = databaseOptions.Value;
            _connectionString = !string.IsNullOrWhiteSpace(_options.ConnectionString) ? _options.ConnectionString : throw new ArgumentNullException(nameof(_options.ConnectionString));
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
