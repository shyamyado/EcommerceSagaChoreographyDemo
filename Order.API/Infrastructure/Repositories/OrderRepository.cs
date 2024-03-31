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
        public async Task<ProductOrder> CreateOrder(NewOrder newOrder)
        {
            try
            {


                var productOrder = new ProductOrder
                {
                    CustomerId = newOrder.CustomerId,
                    OrderStatus = "Pending",
                    ProductId = newOrder.ProductId,
                    Quantity = newOrder.Quantity,
                    //CreatedDate = DateTime.UtcNow,
                    //UpdatedDate = DateTime.UtcNow
                };

                _orderDBContext.ProductOrders.Add(productOrder);
                _orderDBContext.SaveChanges();
                return productOrder;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error occured : --------{ex}");
            }
            return null;
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
