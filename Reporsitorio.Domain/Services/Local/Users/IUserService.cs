using Repositorio.Common.Classes.DTO.Local.Users;

namespace Repositorio.Domain.Services.Local.Users
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO RegisterUser(UserDTO User);
        string GenerateToken(UserDTO User);

        AuthenticateResponse GetToken(AuthenticateRequest model);
        UserDTO LoginUser(AuthenticateRequest model);
        UserDTO GetUserbyId(int id);

    }
}
