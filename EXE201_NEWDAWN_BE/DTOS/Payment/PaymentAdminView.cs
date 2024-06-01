namespace DTOS.Payment
{
    public class PaymentAdminView
    {
        public int TransactionID { get; set; }
        public string AccountBank { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string Username { get; set; }
        public double TotalAmout { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }
    }
}
