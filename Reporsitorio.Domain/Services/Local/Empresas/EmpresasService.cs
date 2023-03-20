using AutoMapper;
using Repositorio.Common.Classes.DTO.Local.Empresas;
using Repositorio.Infraestructura.Repositories.Database.Entities.Empresas;
using Repositorio.Infraestructura.Repositories.EntityFramework.Local.Empresas;

namespace Repositorio.Domain.Services.Local.Empresas
{
    public class EmpresasService : IEmpresasService
    {
        private readonly IEmpresasRepository _empresasRepository;
        private readonly IMapper _mapper;

        public EmpresasService(IEmpresasRepository empresasRepository, IMapper mapper)
        {
            _empresasRepository = empresasRepository;
            _mapper = mapper;
        }

        public async Task<EmpresaDatosAdicionalesContract> GetEmpresaDatosAdicionales(int idEmpresa)
        {
            return _mapper.Map<EmpresaDatosAdicionalesContract>(await _empresasRepository.GetEmpresaDatosAdicionales(idEmpresa));
        }

        public async Task<EmpresasContract> GetInfoEmpresa(EmpresasContract empresa)
        {
            EmpresasContract dataEmpresa = _mapper.Map<EmpresasContract>(await _empresasRepository.GetInfoEmpresa(_mapper.Map<EmpresasEntities>(empresa)));
            if (dataEmpresa != null)
            {
                dataEmpresa.DatosAdicionales = _mapper.Map<EmpresaDatosAdicionalesContract>(await _empresasRepository.GetEmpresaDatosAdicionales(dataEmpresa.IdEmpresa));
            }
            return dataEmpresa;
        }

        public async Task<EmpresasContract> GetInfoEmpresabyID(int id)
        {
            EmpresasContract empresa = _mapper.Map<EmpresasContract>(await _empresasRepository.GetInfoEmpresabyID(id));
            if (empresa != null)
            {
                empresa.DatosAdicionales = _mapper.Map<EmpresaDatosAdicionalesContract>(await _empresasRepository.GetEmpresaDatosAdicionales(empresa.IdEmpresa));
            }
            return empresa;
        }
    }
}
