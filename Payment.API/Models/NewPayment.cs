namespace Payment.API.Models
{
    public class NewPayment
    {
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
