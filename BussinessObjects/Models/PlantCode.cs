namespace BussinessObjects.Models
{
    public class PlantCode
    {
        public string PlantCodeID { get; set; }

        public int PaymentTransactionDetailID { get; set; }
        public PaymentTransactionDetail PaymentTransactionDetail { get; set; }
        public int OwnerID { get; set; }
        public UserInformation UserInformation { get; set; }
        public string Provice {  get; set; }
        public string ProviceAddress { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }

        public IEnumerable<PlantTracking> PlantTrackings { get; set; }

    }
}
