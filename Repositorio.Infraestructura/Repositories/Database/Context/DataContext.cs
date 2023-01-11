using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Repositorio.Infraestructura.Repositories.Database.Entities.Common;
using Repositorio.Infraestructura.Repositories.Database.Entities.Empresas;
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
        public virtual DbSet<EmpresasEntities> Empresas { get; set; }
        public virtual DbSet<TemplateDocumentosEntities> Template_Documentos { get; set; }
        #endregion

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repositorio"));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(e => new { e.UserId });
            modelBuilder.Entity<EmpresasEntities>().ToTable("Empresas");
            modelBuilder.Entity<TemplateDocumentosEntities>().ToTable("Templates_Documentos");
            base.OnModelCreating(modelBuilder);
        }
    }
}
