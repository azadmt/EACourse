using Microsoft.EntityFrameworkCore;
using OrdeManagement.Domain;

namespace OrderManagement.Persistence.Ef
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}