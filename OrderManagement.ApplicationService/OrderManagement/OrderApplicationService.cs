//using Framework.Core.Domain;
//using OrderManagement.Domain.OrderAggregate;
//using OrderManagement.DomainContract;

//namespace OrderManagement.ApplicationService
//{
//    public class OrderApplicationService
//    {
//        private IOrderRepository _orderRepository;
//        private readonly IGuidProvider guidProvider;

//        public OrderApplicationService(IOrderRepository orderRepository, IGuidProvider guidProvider)
//        {
//            _orderRepository = orderRepository;
//            this.guidProvider = guidProvider;
//        }

//        public void CreateOrder(CreateOrderDto createOrderDto)
//        {
//            //validate dto
//            var order = OrderManagement.Domain.Order.CreateOrder(createOrderDto, guidProvider);

//            _orderRepository.Save(order);
//        }

//        public void AddOrderItem(AddOrderItemCommand addOrderItemDto)
//        {
//            var order = _orderRepository.Get(addOrderItemDto.OrderId);
//            order.AddOrderItems(addOrderItemDto.OrderItemDtos);
//            _orderRepository.Update(order);
//        }
//    }
//}//using Framework.Core.Domain;
//using OrderManagement.Domain.OrderAggregate;
//using OrderManagement.DomainContract;

//namespace OrderManagement.ApplicationService
//{
//    public class OrderApplicationService
//    {
//        private IOrderRepository _orderRepository;
//        private readonly IGuidProvider guidProvider;

//        public OrderApplicationService(IOrderRepository orderRepository, IGuidProvider guidProvider)
//        {
//            _orderRepository = orderRepository;
//            this.guidProvider = guidProvider;
//        }

//        public void CreateOrder(CreateOrderDto createOrderDto)
//        {
//            //validate dto
//            var order = OrderManagement.Domain.Order.CreateOrder(createOrderDto, guidProvider);

//            _orderRepository.Save(order);
//        }

//        public void AddOrderItem(AddOrderItemCommand addOrderItemDto)
//        {
//            var order = _orderRepository.Get(addOrderItemDto.OrderId);
//            order.AddOrderItems(addOrderItemDto.OrderItemDtos);
//            _orderRepository.Update(order);
//        }
//    }
//}