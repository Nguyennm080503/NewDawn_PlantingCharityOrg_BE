using BussinessObjects.Enumeration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;

namespace Service.Helper
{
    public static class ImageHandler
    {
        public static async Task<string> UploadImageToFileReturnURL(IWebHostEnvironment webHostEnvironment, IFormFile formFile, EnumTypeFolderImage type, string uniqueID)
        {
            if (formFile.Length == 0) return null;

            var folderPath = GetFolderPath(webHostEnvironment, type);

            EnsureDirectoryExists(folderPath);

            var (filePath, returnFilePath) = GetUniqueFilePath(folderPath, uniqueID, Path.GetExtension(formFile.FileName));

            try
            {
                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                }
                return returnFilePath;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while uploading the file.", ex);
            }
        }

        private static string GetFolderPath(IWebHostEnvironment webHostEnvironment, EnumTypeFolderImage fileType)
        {
            var contentPath = webHostEnvironment.ContentRootPath;
            return Path.Combine(contentPath, "Uploads", fileType.ToString());
        }
        private static void EnsureDirectoryExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }
        private static (string filePath, string returnFilePath) GetUniqueFilePath(string folderPath, string uniqueID, string fileExtension)
        {
            var fileName = uniqueID + fileExtension;
            var filePath = Path.Combine(folderPath, fileName);
            var returnFilePath = Path.Combine("Uploads", folderPath, fileName);
            var count = 0;

            while (File.Exists(filePath))
            {
                count++;
                var newFileName = $"{uniqueID}_{count}{fileExtension}";
                filePath = Path.Combine(folderPath, newFileName);
                returnFilePath = Path.Combine("Uploads", folderPath, newFileName);
            }
            return (filePath, returnFilePath);
        }

    }
}
