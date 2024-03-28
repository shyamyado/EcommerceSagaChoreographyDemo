using Microsoft.EntityFrameworkCore;
using Payment.API.Models;

namespace Payment.API.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDBContext _paymentDBContext;

        public PaymentRepository(PaymentDBContext paymentDBContext)
        {
            _paymentDBContext = paymentDBContext ?? throw new ArgumentNullException(nameof(paymentDBContext));
        }
        public async Task<PaymentOrder> AddPayment(NewPayment newPayment)
        {
            var payment = new PaymentOrder
            {
                OrderId = newPayment.OrderId,
                Amount = newPayment.Amount,
                PaymentStatus = newPayment.PaymentStatus,
                PaymentDate = DateTime.UtcNow
            };

            await _paymentDBContext.PaymentOrders.AddAsync(payment);
            _paymentDBContext.SaveChanges();
            return payment;

        }

        public async Task<PaymentOrder> GetPaymentById(int paymentId)
        {
            var payment = await _paymentDBContext.PaymentOrders.FirstOrDefaultAsync(o => o.OrderId == paymentId);
            return payment;
        }

        public async Task<PaymentOrder> UpdatePayment(int id, NewPayment newPayment)
        {
            var payment = _paymentDBContext.PaymentOrders.FirstOrDefault(p => p.PaymentId == id);
            if (payment != null)
            {
                payment.OrderId = newPayment.OrderId;
                payment.Amount = newPayment.Amount;
                payment.PaymentStatus = payment.PaymentStatus;
                _paymentDBContext.Entry(payment).CurrentValues.SetValues(payment);
                _paymentDBContext.SaveChanges();
            }
            return payment;
        }
    }
}
