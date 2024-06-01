using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class PlantTrackingDAO : BaseDAO<PlantTracking>
    {
        private static PlantTrackingDAO instance = null;
        private readonly DataContext dataContext;

        private PlantTrackingDAO()
        {
            dataContext = new DataContext();
        }

        public static PlantTrackingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlantTrackingDAO();
                }
                return instance;
            }
        }

        public async Task<IEnumerable<PlantTracking>> GetAllTrackingOfPlantCode(string plantcode)
        {
            return await dataContext.PlantTracking.Include(x => x.PlantCode).Where(x => x.PlantCodeID == plantcode).ToListAsync();
        }

        public async Task<int> GetTotalPlantWasPlanted()
        {
            return dataContext.PlantTracking.Where(x => x.Status == 2).Count();
        }
    }
}
