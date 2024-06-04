using DTOS.PlantTracking;

namespace Repository.Interface
{
    public interface IPlantTrackingRepository
    {
        Task<IEnumerable<PlantTrackingView>> GetAllTrackingDetailOfPlantCode(string plantcode);
        Task CreateFirstTrackingPlantCode(string plantcode);
        Task CreateTrackingPlantCode(PlantTrackingCreate trackingCreate, List<string> listTracking);
    }
}
