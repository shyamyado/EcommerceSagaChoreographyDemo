using Microsoft.EntityFrameworkCore;
using Stock.API.Model;

namespace Stock.API.Infrastucture.Repositories
{
    public class OrderPaymentRespository : IOrderPaymentRespository
    {
        private readonly StockDBContext _dbContext;

        public OrderPaymentRespository(StockDBContext stockDBContext)
        {
                _dbContext = stockDBContext;
        }

        public Task<OrderPayment> AddOrder(OrderPayment orderPayment)
        {
            throw new NotImplementedException();
        }
        
    }
}
