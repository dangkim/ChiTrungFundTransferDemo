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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly DatabaseOptions _options;
        private string _connectionString = string.Empty;

        public EmployeeRepository(ChiTrungContext context, IOptions<DatabaseOptions> databaseOptions)
            : base(context)
        {
            _options = databaseOptions.Value;
            _connectionString = !string.IsNullOrWhiteSpace(_options.ConnectionString) ? _options.ConnectionString : throw new ArgumentNullException(nameof(_options.ConnectionString));
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.IsDeleted == false);
        }

        public async Task<IEnumerable<Employee>> GetEmployeeByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Employee>(
                  @"SELECT first_name, last_name
                    FROM  employee
                    WHERE first_name like @value Or last_name like @value
                    AND IsDeleted == false"
                        , new { value = "%" + name + "%" }
                    );

                return result;
            }
        }
    }
}
