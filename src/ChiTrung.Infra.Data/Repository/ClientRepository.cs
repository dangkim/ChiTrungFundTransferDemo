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
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DatabaseOptions _options;
        private string _connectionString = string.Empty;

        public ClientRepository(ChiTrungContext context, IOptions<DatabaseOptions> databaseOptions)
            : base(context)
        {
            _options = databaseOptions.Value;
            _connectionString = !string.IsNullOrWhiteSpace(_options.ConnectionString) ? _options.ConnectionString : throw new ArgumentNullException(nameof(_options.ConnectionString));
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
                    AND IsDeleted == false"
                        , new { value = "%" + name + "%" }
                    );

                return result;
            }
        }
    }
}
