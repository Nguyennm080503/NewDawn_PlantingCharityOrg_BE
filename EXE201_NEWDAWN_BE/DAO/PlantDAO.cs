using BussinessObjects.Models;

namespace DAO
{
    internal class PlantDAO : BaseDAO<Plant>
    {
        private static PlantDAO instance = null;
        private readonly DataContext dataContext;

        private PlantDAO()
        {
            dataContext = new DataContext();
        }

        public static PlantDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlantDAO();
                }
                return instance;
            }
        }
    }
}
