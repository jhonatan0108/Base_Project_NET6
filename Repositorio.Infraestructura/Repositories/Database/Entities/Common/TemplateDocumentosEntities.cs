using System.ComponentModel.DataAnnotations;

namespace Repositorio.Infraestructura.Repositories.Database.Entities.Common
{
    public class TemplateDocumentosEntities
    {
        [Key]
        public int IdTemplate { get; set; }
        public int IdEmpresa { get; set; }
        public string TemplateName { get; set; } = string.Empty;
        public int TemplateStatus { get; set; }
        public string TemplateHtml { get; set; } = string.Empty;
    }
}
