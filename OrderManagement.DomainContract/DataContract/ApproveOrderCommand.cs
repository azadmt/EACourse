using Framework.Core.Messeaging;

namespace OrderManagement.DomainContract
{
    public class ApproveOrderCommand : ICommand
    {
        public Guid OrderId { get; set; }
        
        public bool Validate()
        {
            return true;
        }
    }
}
