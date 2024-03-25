using Order.API.Infrastructure.Repositories;
using Order.API.Model;

namespace Order.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Task<ProductOrder> CreateOder(NewOrder newOrder)
        {
            var order = _orderRepository.CreateOder(newOrder);
            return order;
        }

        public Task<ProductOrder> GetOrderById(int OrderId)
        {
            var order = _orderRepository.GetOrderById(OrderId);
            return order;
        }

        public async Task<ProductOrder> UpdateOrder(NewOrder changeOrder)
        {
            var updatedOrder = await _orderRepository.UpdateOrder(changeOrder);
            return updatedOrder;
        }
    }
}
