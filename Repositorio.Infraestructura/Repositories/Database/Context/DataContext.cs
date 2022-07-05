using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositorio.Infraestructura.Repositories.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Infraestructura.Repositories.Database.Context
{
    public class DataContext : DbContext
    {
        public IConfiguration _configuration { get; }
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repositorio"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #region DBSets
        public DbSet<SuperHero> SuperHero => Set<SuperHero>();
        #endregion
    }
}
