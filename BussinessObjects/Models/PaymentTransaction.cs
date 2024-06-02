namespace BussinessObjects.Models
{
    public class PaymentTransaction
    {
        public int TransactionID { get; set; }
        public string AccountBank { get; set; }
        public string BankCode { get; set; }
        public string BankName { get; set;}
        public int AccountID { get; set; }
        public UserInformation UserInformation { get; set; }
        public string? PaymentText { get; set; }
        public double TotalAmout { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }

        public IEnumerable<PaymentTransactionDetail> PaymentTransactionDetails { get; set; }
    }
}
