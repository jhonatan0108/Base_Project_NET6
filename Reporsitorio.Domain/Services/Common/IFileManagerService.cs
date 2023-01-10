

namespace Repositorio.Domain.Services.Common
{
    public interface IFileManagerService
    {
        string SaveFileToRoute(Microsoft.AspNetCore.Http.IFormFile formFile);
        void DeleteFilesToRoute();
    }
}
