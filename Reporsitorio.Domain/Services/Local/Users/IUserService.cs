using Repositorio.Common.Classes.DTO.Local.Users;

namespace Repositorio.Domain.Services.Local.Users
{
    public interface IUserService
    {
        bool IsAuthenticated(UserDTO User);
        UserDTO RegisterUser(UserDTO User);
        string GenerateToken(UserDTO User);

        AuthenticateResponse Authenticate(AuthenticateRequest model);

        UserDTO GetUserbyId(int id);
    }
}
