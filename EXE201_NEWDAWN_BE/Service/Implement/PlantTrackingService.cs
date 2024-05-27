using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PlantTrackingService : IPlantTrackingService
    {
        private readonly IPlantTrackingRepository _plantTrackingRepository;
        public PlantTrackingService(IPlantTrackingRepository plantTrackingRepository) 
        {
            _plantTrackingRepository = plantTrackingRepository;
        }
    }
}
