using DTOS.PlantTracking;

namespace Service.Interface
{
    public interface IPlantTrackingService
    {
        Task<IEnumerable<PlantTrackingView>> GetAllTrackingDetailOfPlantCode(string plantcode);
        Task CreateFirstTrackingPlantCode(string plantcode);
        Task<int> GetTotalPlantWasPlanted();
    }
}
