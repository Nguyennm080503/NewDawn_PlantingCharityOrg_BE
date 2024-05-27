namespace BussinessObjects.Models
{
    public class PlantCode
    {
        public string PlantCodeID { get; set; }
        public int PlantID { get; set; }
        public Plant Plant {  get; set; }
        public int OwnerID { get; set; }
        public UserInformation UserInformation { get; set; }

        public IEnumerable<PlantTracking> PlantTrackings { get; set; }

    }
}
