using Microsoft.EntityFrameworkCore;
using Repositorio.Infraestructura.Repositories.Database.Context;
using Repositorio.Infraestructura.Repositories.Database.Entities.Common;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local.Common
{
    public class TemplateDocumentosRepository : ITemplateDocumentosRepository
    {
        private readonly DataContext _context;

        public TemplateDocumentosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TemplateDocumentosEntities> GetTemplate(TemplateDocumentosEntities request)
        {
            return await _context.Template_Documentos.FirstOrDefaultAsync(x => x.IdEmpresa == request.IdEmpresa && x.TemplateName == request.TemplateName);
        }
    }
}
