using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Repositorio.Common.Classes.DTO.Helpers;
using Repositorio.Infraestructura.Repositories.Database.Context;
using System.Reflection;

namespace Repositorio.Config.Dependencies
{
    public class Local
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region Mapper

            services.AddMemoryCache();
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();

            //var mapper = configMapper.CreateMapper();
            services.AddSingleton(configMapper);
            #endregion
            #region Conexion Base de datos
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Repositorio"));
            });

            services.AddSingleton<IConfiguration>(configuration);

            services.AddScoped<DataContext, DataContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Register DI
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("Repositorio.Domain"),
                Assembly.Load("Repositorio.Infraestructura"),
                Assembly.Load("Repositorio.Common")
            };

            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Repository") ||
                       c.Name.EndsWith("Service") ||
                       c.Name.EndsWith("Validator") ||
                       c.Name.EndsWith("Localizer") ||
                       c.Name.EndsWith("Resource") ||
                       c.Name.EndsWith("Utils"))
                .AsPublicImplementedInterfaces();

            #endregion Register DI

            services.Configure<AppSettings>(configuration.GetSection("Jwt:SecretKey"));

        }
    }
}
