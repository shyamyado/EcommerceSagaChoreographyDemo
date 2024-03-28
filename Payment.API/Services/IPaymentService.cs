using Payment.API.Models;

namespace Payment.API.Services
{
    public interface IPaymentService
    {
        public Task<PaymentOrder> AddPayment(NewPayment newPayment);
        public Task<PaymentOrder> GetPaymentById(int paymentId);
        public Task<PaymentOrder> UpdatePayment(int id, NewPayment newPayment);
    }
}
