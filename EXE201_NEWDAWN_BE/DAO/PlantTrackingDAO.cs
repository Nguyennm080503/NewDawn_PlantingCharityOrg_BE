using BussinessObjects.Models;

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
    }
}
