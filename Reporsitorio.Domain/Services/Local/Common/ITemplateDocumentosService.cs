using Repositorio.Common.Classes.DTO.Common;

namespace Repositorio.Domain.Services.Local.Common
{
    public interface ITemplateDocumentosService
    {
        /// <summary>
        /// Metodo para devolver el template para generar un documento
        /// </summary>
        /// <param name="request">parametros de busqueda</param>
        /// <returns>Template del documento</returns>
        Task<TemplateDocumentosContract> GetTemplate(TemplateDocumentosContract request);
    }
}
