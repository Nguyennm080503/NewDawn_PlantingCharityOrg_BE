using DTOS.PlantTracking;
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

        public async Task<IEnumerable<PlantTrackingView>> GetAllTrackingDetailOfPlantCode(string plantcode)
        {
            return await _plantTrackingRepository.GetAllTrackingDetailOfPlantCode(plantcode);
        }

        public async Task CreateFirstTrackingPlantCode(string plantcode)
        {
            await _plantTrackingRepository.CreateFirstTrackingPlantCode(plantcode);
        }

        public async Task<int> GetTotalPlantWasPlanted()
        {
            return await _plantTrackingRepository.GetTotalPlantWasPlanted();
        }
    }
}
