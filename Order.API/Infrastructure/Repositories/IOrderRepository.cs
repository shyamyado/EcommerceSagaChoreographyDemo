﻿using Order.API.Model;

namespace Order.API.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        public Task<ProductOrder> CreateOder(NewOrder newOrder);
        public Task<ProductOrder> GetOrderById(int OrderId);
        public Task<ProductOrder> UpdateOrder(ChangeOrder changeOrder);
    }
}
