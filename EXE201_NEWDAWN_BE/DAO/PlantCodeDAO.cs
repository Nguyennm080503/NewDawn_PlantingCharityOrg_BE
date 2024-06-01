using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class PlantCodeDAO : BaseDAO<PlantCode>
    {
        private static PlantCodeDAO _instance;
        private static DataContext dataContext;
        private static readonly object _lock = new object();

        private PlantCodeDAO() {
            dataContext = new DataContext();
        }

        public static PlantCodeDAO Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PlantCodeDAO();
                    }
                }
                return _instance;
            }
        }

        public async Task<IEnumerable<PlantCode>> GetAllPlantCodeOfUser(int accountID) 
        {
            return await dataContext.PlantCode.Where(x => x.OwnerID == accountID).OrderByDescending(x => x.DateCreate).ToListAsync();
        }

        public async Task<IEnumerable<PlantCode>> GetAllPlantCodes()
        {
            return await dataContext.PlantCode.Include(x => x.UserInformation).OrderByDescending(x => x.DateCreate).ToListAsync();
        }

        public async Task<IEnumerable<PlantCode>> Get6PlantCodes()
        {
            return await dataContext.PlantCode.Include(x => x.UserInformation).OrderByDescending(x => x.DateCreate).Take(6).ToListAsync();
        }

        public async Task<string> GetLatestPlantCode()
        {
            using (var dataContext = new DataContext())
            {
                var latestPlantCode = await dataContext.PlantCode
                    .OrderByDescending(x => x.PlantCodeID)
                    .FirstOrDefaultAsync();

                return latestPlantCode?.PlantCodeID ?? string.Empty;
            }
        }
    }
}
