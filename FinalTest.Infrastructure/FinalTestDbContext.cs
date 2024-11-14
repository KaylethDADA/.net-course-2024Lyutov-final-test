using FinalTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FinalTest.Infrastructure
{
    public class FinalTestDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorData { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public FinalTestDbContext(DbContextOptions<FinalTestDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
