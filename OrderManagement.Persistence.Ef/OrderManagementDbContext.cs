using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.OrderAggregate;

namespace OrderManagement.Persistence.Ef
{
    public class OrderManagementDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public OrderManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}