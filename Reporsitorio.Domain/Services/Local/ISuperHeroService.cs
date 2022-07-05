
using Repositorio.Common.Classes.DTO.Local;

namespace Repositorio.Domain.Services.Local
{
    public interface ISuperHeroService
    {
        List<SuperHeroDTO> SelectAll();
        SuperHeroDTO FindbyId(int id);
        void Insert(SuperHeroDTO hero);
        void Update(SuperHeroDTO hero);
        void Delete(int id);
    }
}
