using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class PlantCodeService : IPlantCodeService
    {
        private readonly IPlantCodeRepository _plantCodeRepository;
        public PlantCodeService(IPlantCodeRepository plantCodeRepository) 
        {
            _plantCodeRepository = plantCodeRepository;
        }
    }
}
