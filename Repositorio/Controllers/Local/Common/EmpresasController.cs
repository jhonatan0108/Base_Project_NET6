using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Local.Empresas;
using Repositorio.Common.Classes.Response;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Domain.Services.Local.Empresas;

namespace Repositorio.Controllers.Local.Common
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresasService _empresasService;

        public EmpresasController(IEmpresasService empresasService)
        {
            _empresasService = empresasService;
        }
        [HttpGet]
        [Route("GetInfobyId")]

        public async Task<ResponseHandler<EmpresasContract>> GetInfoEmpresa(int id)
        {
            ResponseHandler<EmpresasContract> response = new();
            response.Data = await _empresasService.GetInfoEmpresabyID(id);
            response.Code = (int)HttpCodes.Ok;
            return response;
        }

        [HttpPost]
        [Route("GetInfo")]

        public async Task<ResponseHandler<EmpresasContract>> GetInfoEmpresa(EmpresasContract empresa)
        {
            ResponseHandler<EmpresasContract> response = new();
            response.Data = await _empresasService.GetInfoEmpresa(empresa);
            response.Code = (int)HttpCodes.Ok;
            return response;
        }
    }
}
