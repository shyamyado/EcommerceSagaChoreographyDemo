using Payment.API.Models;

namespace Payment.API.Infrastructure.Repositories
{
    public interface IPaymentRepository
    {
        public Task<PaymentOrder> AddPayment(NewPayment newPayment);
        public Task<PaymentOrder> GetPaymentById(int paymentId);
        public Task<PaymentOrder> UpdatePayment(int id, NewPayment newPayment);
    }
}
