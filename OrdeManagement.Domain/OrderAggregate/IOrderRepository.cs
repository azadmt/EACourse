using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.OrderAggregate
{
    public interface IOrderRepository
    {
        Order Get(Guid id);

        void Save(Order model);

        void Update(Order model);
    }
}