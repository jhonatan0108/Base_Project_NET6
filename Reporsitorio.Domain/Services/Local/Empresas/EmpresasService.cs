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

        public async Task<EmpresasContract> GetInfoEmpresa(EmpresasContract empresa)
        {
            return _mapper.Map<EmpresasContract>(await _empresasRepository.GetInfoEmpresa(_mapper.Map<EmpresasEntities>(empresa)));
        }

        public async Task<EmpresasContract> GetInfoEmpresabyID(int id)
        {
            return _mapper.Map<EmpresasContract>(await _empresasRepository.GetInfoEmpresabyID(id));
        }
    }
}
