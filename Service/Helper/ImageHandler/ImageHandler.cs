using BussinessObjects.Enumeration;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System.IdentityModel.Tokens.Jwt;

namespace Service.Helper.ImageHandler
{
    public class ImageHandler : IImageHandler
    {
        private readonly IConfiguration _config;
        private readonly CloudinarySettings _cloudinarySettings;
        private readonly Cloudinary _cloudinary;

        public ImageHandler(IConfiguration configuration)
        {
            _config = configuration;
            _cloudinarySettings = _config.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(_cloudinarySettings.CloudName,
                _cloudinarySettings.ApiKey,
                _cloudinarySettings.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public string UploadImageToFileReturnURL(IFormFile File)
        {
            if (File == null) return null;
            var uploadResult = new ImageUploadResult();
            if (File.Length > 0)
            {
                using (var stream = File.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(File.Name, stream)
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            return uploadResult.Uri.ToString();
        }
    }
}
