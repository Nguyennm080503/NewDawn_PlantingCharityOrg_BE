using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ImageDetail>> GetImagesOfTrackingPlantCode(int trackingID) 
        {
            return await dataContext.ImageDetail.Where(x => x.TrackingID == trackingID).ToListAsync();
        }
    }
}
