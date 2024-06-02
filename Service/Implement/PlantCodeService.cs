using DTOS.PlantCode;
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

        public async Task<string> CreatePlantCodeFromOrder(PlantCodeCreate plantCode)
        {
            return await _plantCodeRepository.CreatePlantCodeFromOrder(plantCode);
        }

        public async Task<IEnumerable<Top6PlantCode>> Get6TheNewestPlantCode()
        {
            return await _plantCodeRepository.Get6TheNewestPlantCode();
        }

        public async Task<IEnumerable<PlantCodeView>> GetAllPlantCodeOfUser(int accountid)
        {
            return await _plantCodeRepository.GetAllPlantCodeOfUser(accountid);
        }

        public async Task<IEnumerable<AdminPlantCodeView>> GetAllPlantCodes()
        {
            return await _plantCodeRepository.GetAllPlantCodes();
        }
    }
}
