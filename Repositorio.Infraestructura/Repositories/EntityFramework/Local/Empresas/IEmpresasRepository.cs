using Repositorio.Infraestructura.Repositories.Database.Entities.Empresas;
namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local.Empresas
{
    public interface IEmpresasRepository
    {
        Task<EmpresasEntities> GetInfoEmpresa(EmpresasEntities empresa);
        Task<EmpresasEntities> GetInfoEmpresabyID(int id);
    }
}
