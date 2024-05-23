using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Domain.ACL
{
    public class Customer
    {
        public Guid Id { get; init; }
        public bool IsActive { get; init; }
    }
}
