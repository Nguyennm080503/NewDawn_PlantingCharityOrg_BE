using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.Enum;
using DTOS.ImageTracking;
using DTOS.PlantTracking;
using Repository.Interface;

namespace Repository.Implement
{
    public class PlantTrackingRepository : IPlantTrackingRepository
    {
        private readonly IMapper mapper;

        public PlantTrackingRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PlantTrackingView>> GetAllTrackingDetailOfPlantCode(string plantcode)
        {
            var trackingViews = new List<PlantTrackingView>();
            var trackings = await PlantTrackingDAO.Instance.GetAllTrackingOfPlantCode(plantcode);
            foreach (var tracking in trackings)
            {
                var images = await ImageDetailDAO.Instance.GetImagesOfTrackingPlantCode(tracking.TrackingID);
                var trackingView = mapper.Map<PlantTrackingView>(tracking);
                trackingView.PlantImageDetail = mapper.Map<IEnumerable<ImageDetailView>>(images);

                trackingViews.Add(trackingView);
            }
            return trackingViews;
        }

        public async Task CreateFirstTrackingPlantCode(string plantcode)
        {
            PlantTracking plantTracking = new PlantTracking();
            plantTracking.ContentText = "Hãy đón chờ những sự phát triển tiếp theo của cây nhé";
            plantTracking.DateCreate = DateTime.Now;
            plantTracking.Status = (int)TrackingEnum.Seed;
            plantTracking.PlantCodeID = plantcode;
            await PlantTrackingDAO.Instance.CreateAsync(plantTracking);
        }
    }
}
