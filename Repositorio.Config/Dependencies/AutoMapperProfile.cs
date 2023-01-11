using AutoMapper;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;
using Repositorio.Common.Classes.DTO.Local.Users;
using Repositorio.Infraestructura.Repositories.Database.Entities.SuperHero;
using Repositorio.Common.Classes.DTO.Local.SuperHeores;
using Repositorio.Common.Classes.DTO.Local.Empresas;
using Repositorio.Infraestructura.Repositories.Database.Entities.Empresas;
using Repositorio.Common.Classes.DTO.Common;
using Repositorio.Infraestructura.Repositories.Database.Entities.Common;

namespace Repositorio.Config.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SuperHero, SuperHeroDTO>().ReverseMap();
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<EmpresasContract, EmpresasEntities>().ReverseMap();
            CreateMap<TemplateDocumentosContract, TemplateDocumentosEntities>().ReverseMap();
        }
    }
}
