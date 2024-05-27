namespace BussinessObjects.Models
{
    public class PaymentTransactionDetail
    {
        public int PaymentDetailID { get; set; }
        public int PaymentID { get; set; }
        public PaymentTransaction PaymentTransaction { get; set; }
        public int PlantID { get; set; }
        public Plant Plant { get; set;}
        public int Quantity { get; set; }
        public double TotalQuantity { get; set; }
    }
}
