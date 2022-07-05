using Microsoft.EntityFrameworkCore;
using Repositorio.Infraestructura.Repositories.Database.Context;
using Repositorio.Infraestructura.Repositories.Database.Entities;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly DataContext _context;
        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hero"></param>
        public void Delete(SuperHero hero)
        {
            _context.Remove(hero);
            SaveChanges();
        }

        public SuperHero FindbyId(int id)
        {
            var data = _context.SuperHero.FindAsync(id).Result;
            return data;
        }

        public void Insert(SuperHero hero)
        {
            _context.SuperHero.Add(hero);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<SuperHero> SelectAll()
        {
            return _context.SuperHero.ToList();
        }

        public void Update(SuperHero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
