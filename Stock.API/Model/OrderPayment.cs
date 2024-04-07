namespace Stock.API.Model
{
    public class OrderPayment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set;} 
    }
}
