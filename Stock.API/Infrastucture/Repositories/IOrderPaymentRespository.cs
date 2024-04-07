using Stock.API.Model;

namespace Stock.API.Infrastucture.Repositories
{
    public interface IOrderPaymentRespository
    {
        public Task<OrderPayment> AddOrder(OrderPayment orderPayment);
    }
}
