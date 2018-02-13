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
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private string _connectionString = string.Empty;
        private readonly IConfiguration _config;

        public ServiceRepository(TigersContext context, IConfiguration config)
            : base(context)
        {
            this._config = config;
            _connectionString = this._config.GetConnectionString("DefaultConnection");
        }

        public async Task<Service> GetServiceById(int serviceId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.ServiceId == serviceId);
        }

        public async Task<IEnumerable<Service>> GetServiceByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Service>(
                  @"SELECT first_name, last_name
                    FROM  service
                    WHERE first_name like @value Or last_name like @value
                    AND IsDeleted = 0"
                        , new { value = "%" + name + "%" }
                    );

                return result;
            }
        }
    }
}
