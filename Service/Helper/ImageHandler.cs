using BussinessObjects.Enumeration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System.IdentityModel.Tokens.Jwt;

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

        public static string GetToken(HttpRequest request)
        {
            string authorizationHeader = request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return null;
            }
            string token = authorizationHeader.Substring("Bearer ".Length).Trim();
            try
            {
                // Decode JWT token
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

                if (jsonToken == null)
                {
                    return null;
                }

                // Lấy các claims từ token
                var claims = jsonToken.Claims.Select(claim => new
                {
                    claim.Type,
                    claim.Value
                });

                var strings = claims.Where(x => x.Type == "RoleId").First();

                return strings.Value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
