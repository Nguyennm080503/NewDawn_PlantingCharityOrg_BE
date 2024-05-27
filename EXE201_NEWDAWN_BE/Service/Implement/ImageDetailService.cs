using Repository.Interface;
using Service.Interface;

namespace Service.Implement
{
    public class ImageDetailService : IImageDetailService
    {
        private readonly IImageDetailRepository _imageDetailRepository;

        public ImageDetailService(IImageDetailRepository imageDetailRepository)
        {
            _imageDetailRepository = imageDetailRepository;
        }
    }
}
