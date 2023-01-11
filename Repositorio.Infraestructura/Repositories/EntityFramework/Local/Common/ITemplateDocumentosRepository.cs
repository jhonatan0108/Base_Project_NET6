using Repositorio.Infraestructura.Repositories.Database.Entities.Common;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local.Common
{
    public interface ITemplateDocumentosRepository
    {
        Task<TemplateDocumentosEntities> GetTemplate(TemplateDocumentosEntities request);
    }
}
