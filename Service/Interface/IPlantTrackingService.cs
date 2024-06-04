using DTOS.PlantTracking;
using Microsoft.AspNetCore.Hosting;

namespace Service.Interface
{
    public interface IPlantTrackingService
    {
        Task<IEnumerable<PlantTrackingView>> GetAllTrackingDetailOfPlantCode(string plantcode);
        Task CreateFirstTrackingPlantCode(string plantcode);
        Task CreatePlantTracking(IWebHostEnvironment webHostEnvironment, PlantTrackingCreate trackingCreate);
    }
}
