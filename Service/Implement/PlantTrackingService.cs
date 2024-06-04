using DTOS.News;
using DTOS.PlantTracking;
using Microsoft.AspNetCore.Hosting;
using Repository.Interface;
using Service.Helper.ImageHandler;
using Service.Interface;

namespace Service.Implement
{
    public class PlantTrackingService : IPlantTrackingService
    {
        private readonly IPlantTrackingRepository _plantTrackingRepository;
        private readonly IImageHandler _imageHandler;
        public PlantTrackingService(IPlantTrackingRepository plantTrackingRepository, IImageHandler imageHandler) 
        {
            _plantTrackingRepository = plantTrackingRepository;
            _imageHandler = imageHandler;
        }

        public async Task<IEnumerable<PlantTrackingView>> GetAllTrackingDetailOfPlantCode(string plantcode)
        {
            return await _plantTrackingRepository.GetAllTrackingDetailOfPlantCode(plantcode);
        }

        public async Task CreateFirstTrackingPlantCode(string plantcode)
        {
            await _plantTrackingRepository.CreateFirstTrackingPlantCode(plantcode);
        }

        public async Task CreatePlantTracking(IWebHostEnvironment webHostEnvironment, PlantTrackingCreate trackingCreate)
        {
            var listTracking = new List<string>();
            foreach (var url in trackingCreate.PlantImageDetails)
            {
                String urlImage = _imageHandler.UploadImageToFileReturnURL(url);
                listTracking.Add(urlImage);
            }
            await _plantTrackingRepository.CreateTrackingPlantCode(trackingCreate, listTracking);
        }
    }
}
