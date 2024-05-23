using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.ApplicationService.ACL
{
    public interface ICustomerDataProvider
    {
        Domain.ACL.Customer GetCustomer(Guid id);
    }

}
