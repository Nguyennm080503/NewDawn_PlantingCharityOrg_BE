using BussinessObjects.Models;

namespace DAO
{
    public class ImageDetailDAO : BaseDAO<ImageDetail>
    {
        private static ImageDetailDAO instance = null;
        private readonly DataContext dataContext;

        private ImageDetailDAO()
        {
            dataContext = new DataContext();
        }

        public static ImageDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImageDetailDAO();
                }
                return instance;
            }
        }
    }
}
