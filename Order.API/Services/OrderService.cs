﻿using Order.API.Infrastructure.Repositories;
using Order.API.Model;
using RabbitMQEventBus;

namespace Order.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRabbitMQPersistantConnection _rabbitMQPersistantConnection;

        public OrderService(IOrderRepository orderRepository, IRabbitMQPersistantConnection rabbitMQPersistantConnection)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _rabbitMQPersistantConnection = rabbitMQPersistantConnection ?? throw new ArgumentNullException(nameof(rabbitMQPersistantConnection));
        }
        public async Task<ProductOrder> CreateOrder(NewOrder newOrder)
        {
            var order = await _orderRepository.CreateOrder(newOrder);
            string eventMsgQueueName = "new_order";
            _rabbitMQPersistantConnection.Publish(eventMsgQueueName, newOrder);
            return order;
        }

        public Task<ProductOrder> GetOrderById(int OrderId)
        {
            var order = _orderRepository.GetOrderById(OrderId);
            return order;
        }

        public async Task<ProductOrder> UpdateOrder(ChangeOrder changeOrder)
        {
            var updatedOrder = await _orderRepository.UpdateOrder(changeOrder);
            return updatedOrder;
        }
    }
}
