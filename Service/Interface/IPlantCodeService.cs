using DTOS.PlantCode;

namespace Service.Interface
{
    public interface IPlantCodeService
    {
        Task<IEnumerable<PlantCodeView>> GetAllPlantCodeOfUser(int accountid);
        Task<IEnumerable<AdminPlantCodeView>> GetAllPlantCodes();
        Task<string> CreatePlantCodeFromOrder(PlantCodeCreate plantCode);
        Task<IEnumerable<Top6PlantCode>> Get6TheNewestPlantCode();
    }
}
