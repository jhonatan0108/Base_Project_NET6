

using Microsoft.EntityFrameworkCore;

namespace Repositorio.Infraestructura.Repositories.Database.Context
{
    public class DbInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
