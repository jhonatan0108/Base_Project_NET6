using Repositorio.Common.Classes.Enums.Users;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;

namespace Repositorio.Common.Classes.DTO.Local.Users
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public RoleEnum Role { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(UserDTO user, string token)
        {
            UserId = user.UserId;
            Username = user.Username;
            Email = user.Email;
            //Role = (RoleEnum)Enum.Parse(typeof(RoleEnum), user.Role.ToString());
            Token = token;
        }
    }
}
