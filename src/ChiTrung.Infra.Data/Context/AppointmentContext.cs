using System.IO;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Mappings;
using ChiTrung.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChiTrung.Infra.Data.Context
{
    public class AppointmentContext : DbContext
    {
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceProvided> ServiceProvided { get; set; }
        public DbSet<ServiceBooked> ServiceBooked { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ScheduleMap());
            modelBuilder.AddConfiguration(new EmployeeMap());
            modelBuilder.AddConfiguration(new ClientMap());
            modelBuilder.AddConfiguration(new AppointmentMap());
            modelBuilder.AddConfiguration(new ServiceMap());
            modelBuilder.AddConfiguration(new ServiceProvidedMap());
            modelBuilder.AddConfiguration(new ServiceBookedMap());

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
