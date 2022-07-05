using Repositorio.Infraestructura.Repositories.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local
{
    public interface ISuperHeroRepository
    {
        List<SuperHero> SelectAll();
        SuperHero FindbyId(int id);
        void Insert(SuperHero hero);
        void Update(SuperHero hero);
        void Delete(SuperHero id);
        void SaveChanges();
    }
}
