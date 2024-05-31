using BussinessObjects.Enumeration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;

namespace Service.Helper
{
    public static class ImageHandler
    {
        public static async Task<string> UploadImageToFileReturnURL(IWebHostEnvironment webHostEnvironment, IFormFile formFile, string type, string uniqueID)
        {
            if (formFile.Length > 0)
            {
                var contentPath = webHostEnvironment.ContentRootPath;
                var folderPath = Path.Combine(contentPath, "Uploads", type);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var extentionFile = Path.GetExtension(formFile.FileName);
                var filePath = Path.Combine(folderPath, uniqueID + extentionFile);
                var returnFilePath = Path.Combine("Uploads", type, uniqueID + extentionFile);
                var count = 0;
                while (File.Exists(filePath))
                {
                    count = count + 1;
                    var newFileName = uniqueID + "_" + count;
                    filePath = Path.Combine(folderPath, newFileName + extentionFile);
                    returnFilePath = Path.Combine("Uploads", type, newFileName + extentionFile);
                }
                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
                return returnFilePath;
            }
            return null;
        }

    }
}
