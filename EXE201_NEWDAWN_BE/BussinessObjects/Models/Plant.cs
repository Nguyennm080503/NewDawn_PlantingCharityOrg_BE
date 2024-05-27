namespace BussinessObjects.Models
{
    public class Plant
    {
        public int PlantID { get; set; }
        public string PlantName { get; set;}
        public string PlantDescription { get; set;}
        public string ThumnailUrl { get; set;}
        public double PlantFee {  get; set;}
        public int Status { get; set;}

        public IEnumerable<PlantCode> PlantCodes { get; set;}
        public IEnumerable<PaymentTransactionDetail> PaymentTransactionDetails { get; set;}
    }
}
