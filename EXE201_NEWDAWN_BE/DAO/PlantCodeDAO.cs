using BussinessObjects.Models;

namespace DAO
{
    public class PlantCodeDAO : BaseDAO<PlantCode>
    {
        private static PlantCodeDAO instance = null;
        private readonly DataContext dataContext;

        private PlantCodeDAO()
        {
            dataContext = new DataContext();
        }

        public static PlantCodeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlantCodeDAO();
                }
                return instance;
            }
        }
    }
}
