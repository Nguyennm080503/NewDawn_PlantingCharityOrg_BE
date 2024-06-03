using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helper.ImageHandler
{
    public interface IImageHandler
    {
        string UploadImageToFileReturnURL(IFormFile File);
    }
}
