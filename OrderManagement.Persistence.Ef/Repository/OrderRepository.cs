using OrdeManagement.Domain;
using OrdeManagement.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Persistence.Ef
{
    public class OrderRepository : IOrderRepository
    {
        ApplicationDbContext dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Order Get(Guid id)
        {
            return dbContext.Orders.Single(x=>x.Id==id);
        }

        public void Save(Order model)
        {
            dbContext.Orders.Add(model);     
            dbContext.SaveChanges();
        }

        public void Update(Order model)
        {
            dbContext.Orders.Update(model);
            dbContext.SaveChanges();

        }
    }
}
