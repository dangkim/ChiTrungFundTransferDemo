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
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceProvided> ServiceProvided { get; set; }
        public DbSet<ServiceBooked> ServiceBooked { get; set; }
        public DbSet<RToken> RToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CustomerMap());
            modelBuilder.AddConfiguration(new BankMap());
            modelBuilder.AddConfiguration(new AccountMap());
            modelBuilder.AddConfiguration(new AtmMap());
            modelBuilder.AddConfiguration(new DepositMap());
            modelBuilder.AddConfiguration(new WithdrawalMap());
            modelBuilder.AddConfiguration(new ScheduleMap());
            modelBuilder.AddConfiguration(new EmployeeMap());
            modelBuilder.AddConfiguration(new ClientMap());
            modelBuilder.AddConfiguration(new AppointmentMap());
            modelBuilder.AddConfiguration(new ServiceMap());
            modelBuilder.AddConfiguration(new ServiceProvidedMap());
            modelBuilder.AddConfiguration(new ServiceBookedMap());
            modelBuilder.AddConfiguration(new RTokenMap());

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
