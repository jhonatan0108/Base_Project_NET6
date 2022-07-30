using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositorio.Infraestructura.Repositories.Database.Entities.SuperHero;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;


namespace Repositorio.Infraestructura.Repositories.Database.Context
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        #region DBSets
        public virtual DbSet<SuperHero> SuperHero => Set<SuperHero>();
        public virtual DbSet<UserEntity> Users { get; set; }
        #endregion

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
            modelBuilder.Entity<UserEntity>().HasKey(e => new { e.UserId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
