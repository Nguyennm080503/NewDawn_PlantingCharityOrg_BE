namespace DTOS.PlantTracking
{
    public class PlantTrackingView
    {
        public int TrackingID { get; set; }
        public string PlantCodeID { get; set; }
        public string Provice { get; set; }
        public string ProviceAddress { get; set; }
        public string? ContentText { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }
        public int TotalStatus { get; set; }

        public IEnumerable<string> PlantImageDetail { get; set; }
    }
}
