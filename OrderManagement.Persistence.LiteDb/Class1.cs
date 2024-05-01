using LiteDB;
using OrdeManagement.Domain;
using OrdeManagement.Domain.OrderAggregate;
using System;
using System.Reflection;

namespace OrderManagement.Persistence.LiteDb
{
    public class OrderRepository : IOrderRepository
    {
        private ILiteCollection<Order> _ordersCollection;

        public OrderRepository()
        {
            using (var db = new LiteDatabase($@"{Assembly.GetExecutingAssembly()}\OrderManagement_db.db"))
            {
                // Get a collection (or create, if doesn't exist)
                _ordersCollection = db.GetCollection<Order>("Orders");
            }
        }

        public Order Get(Guid id)
        {
            return _ordersCollection
                  .Query()
                  .Where(x => x.Id == id)
                  .Single();
        }

        public void Save(Order model)
        {
            _ordersCollection.Insert(model);
        }

        public void Update(Order model)
        {
            _ordersCollection.Update(model);
        }
    }
}