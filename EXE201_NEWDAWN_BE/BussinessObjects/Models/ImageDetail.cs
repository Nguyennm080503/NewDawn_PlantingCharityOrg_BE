namespace BussinessObjects.Models
{
    public class ImageDetail
    {
        public int ImageDetailID { get; set; }
        public int TrackingID { get; set; }
        public PlantTracking PlantTracking { get; set; }
        public string Url { get; set; }

    }
}
