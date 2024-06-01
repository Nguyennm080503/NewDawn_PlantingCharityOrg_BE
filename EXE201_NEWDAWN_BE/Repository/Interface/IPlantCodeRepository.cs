using DTOS.PlantCode;

namespace Repository.Interface
{
    public interface IPlantCodeRepository
    {
        Task<IEnumerable<PlantCodeView>> GetAllPlantCodeOfUser(int accountid);
        Task<IEnumerable<AdminPlantCodeView>> GetAllPlantCodes();
        Task<string> CreatePlantCodeFromOrder(PlantCodeCreate plantCode);
        Task<IEnumerable<Top6PlantCode>> Get6TheNewestPlantCode();
        Task<int> GetTotalPlantWasPlanted();
        Task<int> GetTotalPlantWasPlantedEachMonth();
    }
}
