using Repositorio.Common.Classes.DTO.Local;
using Repositorio.Infraestructura.Repositories.Database.Entities;
using AutoMapper;

namespace Repositorio.Config.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
        }
    }
}
