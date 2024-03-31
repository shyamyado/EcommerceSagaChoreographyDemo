using Order.API.Model;

namespace Order.API.Services
{
    public interface IOrderService
    {
        public Task<ProductOrder> CreateOrder(NewOrder newOrder);
        public Task<ProductOrder> GetOrderById(int OrderId);
        public Task<ProductOrder> UpdateOrder(ChangeOrder changeOrder);

    }
}
