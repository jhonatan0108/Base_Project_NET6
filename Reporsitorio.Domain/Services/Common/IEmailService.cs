using Microsoft.AspNetCore.Http;
using Repositorio.Common.Classes.DTO.Common;
namespace Repositorio.Domain.Services.Common
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request, IFormFile? fileAttachment = null);
    }
}
