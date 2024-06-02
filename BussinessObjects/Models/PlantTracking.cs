namespace BussinessObjects.Models
{
    public class PlantTracking
    {
        public int TrackingID { get; set; }
        public string PlantCodeID { get; set; }
        public PlantCode PlantCode { get; set; }
        public string? ContentText { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }

        public IEnumerable<ImageDetail> PlantImageDetails { get; set; }

    }
}
