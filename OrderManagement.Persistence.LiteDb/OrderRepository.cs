using LiteDB;
using OrderManagement.Domain;
using OrderManagement.Domain.OrderAggregate;
using System;
using System.Reflection;

namespace OrderManagement.Persistence.LiteDb
{
    public class OrderRepositoryLiteDbImp : IOrderRepository
    {
        private ILiteCollection<Order> _ordersCollection;

        public OrderRepositoryLiteDbImp()
        {
        }

        public Order Get(Guid id)
        {
            using var LiteDB = GetCollection();
            _ordersCollection = LiteDB.GetCollection<Order>("Orders");
            return _ordersCollection
                  .Query()
                  .Where(x => x.Id == id)
                  .Single();
        }

        public void Save(Order model)
        {
            using var LiteDB = GetCollection();
            _ordersCollection = LiteDB.GetCollection<Order>("Orders");
            _ordersCollection.Insert(model);
        }

        public void Update(Order model)
        {
            using var LiteDB = GetCollection();
            _ordersCollection = LiteDB.GetCollection<Order>("Orders");
            _ordersCollection.Update(model);
        }

        private LiteDatabase GetCollection()
        {
            return new LiteDatabase($@"{AppContext.BaseDirectory}\OrderManagement_db.db");//get from config
        }
    }
}