using Repositorio.Infraestructura.Repositories.Database.Entities.Users;


namespace Repositorio.Domain.Services.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserEntity user);
        public int? ValidateJwtToken(string token);
    }
}
