using Framework.Core.Messeaging;

namespace OrderManagement.DomainContract
{
    public class RejectOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }

        public bool Validate()
        {
            return true;
        }
    }
}
