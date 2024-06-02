namespace DTOS.PlantCode
{
    public class AdminPlantCodeView
    {
        public string PlantCodeID { get; set; }
        public string Username { get; set; }
        public string Provice { get; set; }
        public string ProviceAddress { get; set; }
        public DateTime DateCreate { get; set; }
        public int Status { get; set; }
    }
}
