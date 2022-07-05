using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.Domain.Services.Common;
using Repositorio.Domain.Services.Local;
using Repositorio.Infraestructura.Repositories.Database.Context;
using Repositorio.Infraestructura.Repositories.Database.Entities;
using Repositorio.Infraestructura.Repositories.EntityFramework.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();
            services.AddScoped<ISuperHeroService, SuperHeroService>();
            services.AddScoped<IEmailService, EmailService>();

        }
    }
}
