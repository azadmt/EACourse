using Microsoft.EntityFrameworkCore;
using OrderManagement.QueryApi.DataModel;

namespace OrderManagement.QueryApi
{
    public class OrderManagementQueryDbContext : DbContext
    {
        public OrderManagementQueryDbContext(DbContextOptions<OrderManagementQueryDbContext> dbContextOptions) : base(dbContextOptions) 
        {
                
        }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
}
}
