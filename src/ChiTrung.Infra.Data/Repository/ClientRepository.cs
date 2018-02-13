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
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private string _connectionString = string.Empty;
        private readonly IConfiguration _config;

        public ClientRepository(TigersContext context, IConfiguration config)
            : base(context)
        {
            this._config = config;
            _connectionString = this._config.GetConnectionString("DefaultConnection");
        }

        public async Task<Client> GetClientById(int clientId)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.ClientId == clientId && a.IsDeleted == false);
        }

        public async Task<IEnumerable<Client>> GetClientByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Client>(
                  @"SELECT ClientName, ContactMobile, ContactMail
                    FROM  Client
                    WHERE ClientName like @value 
                    AND IsDeleted = 0"
                        , new { value = "%" + name + "%" }
                    );

                return result;
            }
        }
    }
}
