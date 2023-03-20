using System.ComponentModel.DataAnnotations;

namespace Repositorio.Infraestructura.Repositories.Database.Entities.Empresas
{
    public class EmpresasEntities
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string NombreEmpresa { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public int DigitoVerificacion { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PaginaWeb { get; set; } = string.Empty;
        public string UrlLogo { get; set; } = string.Empty;
        public string Prefijo { get; set; } = string.Empty;
    }
    public class EmpresaDatosAdicionalesEntities
    {
        [Key]
        public int IdEmpresaDato { get; set; }
        public int IdEmpresa { get; set; }
        public string Representante { get; set; } = string.Empty;
        public string Cuenta_Numero { get; set; } = string.Empty;
        public string Cuenta_Tipo { get; set; } = string.Empty;
        public string Cuenta_Banco { get; set; } = string.Empty;
    }
}
