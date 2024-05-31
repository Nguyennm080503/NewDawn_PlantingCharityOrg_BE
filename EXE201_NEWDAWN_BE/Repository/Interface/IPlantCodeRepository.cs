using BussinessObjects.Models;
using DTOS.PlantCode;

namespace Repository.Interface
{
    public interface IPlantCodeRepository
    {
        Task<IEnumerable<PlantCodeView>> GetAllPlantCodeOfUser(int accountid);
        Task<IEnumerable<AdminPlantCodeView>> GetAllPlantCodes();
        Task<string> CreatePlantCodeFromOrder(PlantCodeCreate plantCode);
    }
}
