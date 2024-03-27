using Microsoft.EntityFrameworkCore;
using Order.API.Model;


namespace Order.API.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDBContext _orderDBContext;

        public OrderRepository(OrderDBContext orderDBContext)
        {
            _orderDBContext = orderDBContext;
        }
        public async Task<ProductOrder> CreateOder(NewOrder newOrder)
        {
            var productOrder = new ProductOrder
            {
                CustomerId = newOrder.CustomerId,
                OrderStatus = "Pending",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            var orderEntry = await _orderDBContext.ProductOrders.AddAsync(productOrder);
            await _orderDBContext.SaveChangesAsync();
            return orderEntry.Entity;
        }

        public async Task<ProductOrder> GetOrderById(int OrderId)
        {
            var order = await _orderDBContext.ProductOrders.FirstOrDefaultAsync(x => x.OrderId == OrderId);
            return order;
        }

        public async Task<ProductOrder> UpdateOrder(ChangeOrder changeOrder)
        {
            var existingOrder = _orderDBContext.ProductOrders.FirstOrDefault(x => x.OrderId == changeOrder.OrderId);

            if (existingOrder != null)
            {
                existingOrder.OrderStatus = changeOrder.OrderStatus;

                try
                {
                    await _orderDBContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    throw new Exception("Concurrency conflict occurred while updating the order.", ex);
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("Error occurred while updating the order in the database.", ex);
                }
            }
            else
            {
                throw new Exception("Order not found.");
            }

            return existingOrder;
        }

    }
}
