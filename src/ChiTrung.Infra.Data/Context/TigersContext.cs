using System;
using System.IO;
using ChiTrung.Domain.Models;
using ChiTrung.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChiTrung.Infra.Data.Context
{
    public class TigersContext : DbContext
    {
        public DbSet<ChiTrung.Domain.Models.GameEvents> GameEvents { get; set; }
        public DbSet<ChiTrung.Domain.Models.GameState> GameState { get; set; }
        public DbSet<ChiTrung.Domain.Models.Users> Users { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameEventsMap());
            modelBuilder.ApplyConfiguration(new GameStateMap());
            modelBuilder.ApplyConfiguration(new UsersMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
