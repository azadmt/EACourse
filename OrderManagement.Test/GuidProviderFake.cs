using Framework.Core.Domain;
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
}