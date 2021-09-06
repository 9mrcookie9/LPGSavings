using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace LPGSavings.Domain.Contexts
{
    public class MainContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<FuelingEntry> FuelingHistory { get; set; }
        public DbSet<ServiceEntry> ServiceHistory { get; set; }
        public MainContext()
        {

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, $"{nameof(MainContext)}.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
