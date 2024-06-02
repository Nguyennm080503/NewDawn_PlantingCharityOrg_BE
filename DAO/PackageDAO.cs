using BussinessObjects.Models;
namespace DAO
{
    public class PackageDAO : BaseDAO<Package>
    {
        private static PackageDAO instance = null;
        private readonly DataContext dataContext;

        private PackageDAO()
        {
            dataContext = new DataContext();
        }

        public static PackageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PackageDAO();
                }
                return instance;
            }
        }
    }
}
