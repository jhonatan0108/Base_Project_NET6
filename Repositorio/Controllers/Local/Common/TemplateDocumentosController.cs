using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Common;
using Repositorio.Common.Classes.Response;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Domain.Services.Local.Common;

namespace Repositorio.Controllers.Local.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplateDocumentosController : ControllerBase
    {
        private readonly ITemplateDocumentosService _templateDocumentosService;
        public TemplateDocumentosController(ITemplateDocumentosService templateDocumentosService)
        {
            _templateDocumentosService= templateDocumentosService;  
        }

        [HttpPost]
        public async Task<ResponseHandler<TemplateDocumentosContract>> GetTemplate(TemplateDocumentosContract request)
        {
            ResponseHandler<TemplateDocumentosContract> response = new();
            response.Data = await _templateDocumentosService.GetTemplate(request);
            response.Code = (int)HttpCodes.Ok;
            return response;
        }
    }
}
