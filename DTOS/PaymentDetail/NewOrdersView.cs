namespace DTOS.PaymentDetail
{
    public class NewOrdersView
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public int Quantity { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
