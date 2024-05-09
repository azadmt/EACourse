using OrderManagement.Domain;
using OrderManagement.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Test
{
    internal class OrderRepositoryFake : IOrderRepository
    {
        private List<Order> orders = new List<Order>();

        public Order Get(Guid id)
        {
            return orders.Single(x => x.Id == id);
        }

        public void Save(Order model)
        {
            orders.Add(model);
        }

        public void Update(Order model)
        {
            var order = orders.SingleOrDefault(x => x.Id == model.Id);
            if (orders is null)
            {
                orders.Add(model);
            }
            else
            {
                order = model;
                //rplace new value whit
            }
        }
    }
}