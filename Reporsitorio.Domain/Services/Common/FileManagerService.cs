using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace Repositorio.Domain.Services.Common
{
    public class FileManagerService : IFileManagerService
    {
        public void DeleteFilesToRoute()
        {
            // Delete all files in a directory    
            var folderName = Path.Combine("Resources", "PDF");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            string[] files = Directory.GetFiles(pathToSave);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        public string SaveFileToRoute(IFormFile formFile)
        {
            var file = formFile;
            var folderName = Path.Combine("Resources", "PDF");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fullPath;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
