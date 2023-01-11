using AutoMapper;
using Repositorio.Common.Classes.DTO.Common;
using Repositorio.Infraestructura.Repositories.Database.Entities.Common;
using Repositorio.Infraestructura.Repositories.EntityFramework.Local.Common;

namespace Repositorio.Domain.Services.Local.Common
{
    public class TemplateDocumentosService : ITemplateDocumentosService
    {
        private readonly ITemplateDocumentosRepository _templateDocumentosRepository;
        private readonly IMapper _mapper;
        public TemplateDocumentosService(ITemplateDocumentosRepository templateDocumentosRepository, IMapper mapper)
        {
            _templateDocumentosRepository = templateDocumentosRepository;
            _mapper = mapper;
        }

        public async Task<TemplateDocumentosContract> GetTemplate(TemplateDocumentosContract request)
        {
            return _mapper.Map<TemplateDocumentosContract>(await _templateDocumentosRepository.GetTemplate(_mapper.Map<TemplateDocumentosEntities>(request)));
        }
    }
}
