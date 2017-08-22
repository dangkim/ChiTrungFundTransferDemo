using System.IO;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Mappings;
using ChiTrung.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChiTrung.Infra.Data.Context
{
    public class ChiTrungContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Atm> Atm { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Withdrawal> Withdrawal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CustomerMap());
            modelBuilder.AddConfiguration(new BankMap());
            modelBuilder.AddConfiguration(new AccountMap());
            modelBuilder.AddConfiguration(new AtmMap());
            modelBuilder.AddConfiguration(new DepositMap());
            modelBuilder.AddConfiguration(new WithdrawalMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
