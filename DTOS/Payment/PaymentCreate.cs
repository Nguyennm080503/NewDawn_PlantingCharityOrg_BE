namespace DTOS.Payment
{
    public class PaymentCreate
    {
        public int OrderID { get; set; }
        public int AccountID { get; set; }
        public int Quantity { get; set; }
    }
}
