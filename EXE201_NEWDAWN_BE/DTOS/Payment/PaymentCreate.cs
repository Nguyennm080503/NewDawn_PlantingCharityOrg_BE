namespace DTOS.Payment
{
    public class PaymentCreate
    {
        public string AccountBank { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public int AccountID { get; set; }
        public string? PaymentText { get; set; }
        public double TotalAmout { get; set; }
    }
}
