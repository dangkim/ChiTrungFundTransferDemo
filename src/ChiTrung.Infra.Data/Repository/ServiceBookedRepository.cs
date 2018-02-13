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
    public class ServiceBookedRepository : Repository<ServiceBooked>, IServiceBookedRepository
    {
        private string _connectionString = string.Empty;
        private readonly IConfiguration _config;

        public ServiceBookedRepository(TigersContext context, IConfiguration config)
            : base(context)
        {
            this._config = config;
            _connectionString = this._config.GetConnectionString("DefaultConnection");
        }

        public async Task<ServiceBooked> GetServiceBookedById(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.ServiceBookedId == id);
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
                    AND IsDeleted = 0"
                        , new { value = "%" + name + "%" }
                    );

                return result;
            }
        }
    }
}
