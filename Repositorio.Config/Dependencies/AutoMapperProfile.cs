using Repositorio.Common.Classes.DTO.Local;
using AutoMapper;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;
using Repositorio.Common.Classes.DTO.Local.Users;
using Repositorio.Infraestructura.Repositories.Database.Entities.SuperHero;

namespace Repositorio.Config.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
            CreateMap<UserDTO, UserEntity>().ReverseMap();
        }
    }
}
