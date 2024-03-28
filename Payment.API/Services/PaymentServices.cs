using Payment.API.Infrastructure.Repositories;
using Payment.API.Models;

namespace Payment.API.Services
{
    public class PaymentServices : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentServices(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
        }
        public async Task<PaymentOrder> AddPayment(NewPayment newPayment)
        {
            var payment = await _paymentRepository.AddPayment(newPayment);
            return payment;
        }

        public async Task<PaymentOrder> GetPaymentById(int paymentId)
        {
            var payment = await _paymentRepository.GetPaymentById(paymentId);
            return payment;
        }

        public async Task<PaymentOrder> UpdatePayment(int id, NewPayment newPayment)
        {
            var payment = await _paymentRepository.UpdatePayment(id, newPayment);
            return payment;
        }
    }
}
