using Framework.Core.Domain;
using OrderManagement.ApplicationService.ACL;
using OrderManagement.Domain.ACL;
using System;

namespace OrderManagement.Test
{
    public class GuidProviderFake : IGuidProvider
    {
        private readonly Guid _guid;

        public GuidProviderFake(Guid guid)
        {
            _guid = guid;
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }

    public class CustomerDataProviderFake : ICustomerDataProvider
    {
        public Customer GetCustomer(Guid id)
        {
            return null;
        }
    }
}