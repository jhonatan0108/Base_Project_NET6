using Repositorio.Common.Classes.DTO.Local.Empresas;

namespace Repositorio.Domain.Services.Local.Empresas
{
    public interface IEmpresasService
    {
        /// <summary>
        /// Metodo para devolver info de la empresa
        /// </summary>
        /// <param name="empresa">objeto con datos de consulta</param>
        /// <returns>Empresa</returns>
        Task<EmpresasContract> GetInfoEmpresa(EmpresasContract empresa);

        /// <summary>
        /// Metodo para obtener la info de la empresa por su ID
        /// </summary>
        /// <param name="id">parametro de consulta</param>
        /// <returns>Empresa</returns>
        Task<EmpresasContract> GetInfoEmpresabyID(int id);

        /// <summary>
        /// Metodo para obtener datos adicionales de una empresa el ID
        /// </summary>
        /// <param name="idEmpresa">parametro para la consulta</param>
        /// <returns>Datos Adicionales Empresa</returns>
        Task<EmpresaDatosAdicionalesContract> GetEmpresaDatosAdicionales(int idEmpresa);
    }
}
