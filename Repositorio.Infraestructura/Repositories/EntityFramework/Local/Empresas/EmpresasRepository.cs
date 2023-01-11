using Microsoft.EntityFrameworkCore;
using Repositorio.Infraestructura.Repositories.Database.Context;
using Repositorio.Infraestructura.Repositories.Database.Entities.Empresas;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local.Empresas
{
    public class EmpresasRepository : IEmpresasRepository
    {
        private readonly DataContext _context;

        public EmpresasRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<EmpresasEntities> GetInfoEmpresa(EmpresasEntities empresa)
        {
            return await _context.Empresas.FirstOrDefaultAsync(x => x.TipoDocumento.Trim() == empresa.TipoDocumento.Trim() && x.Identificacion == empresa.Identificacion);
        }

        public async Task<EmpresasEntities> GetInfoEmpresabyID(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }
    }
}
