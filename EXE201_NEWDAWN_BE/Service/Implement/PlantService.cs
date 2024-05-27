using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        public PlantService(IPlantRepository plantRepository) 
        {
            _plantRepository = plantRepository;
        }
    }
}
