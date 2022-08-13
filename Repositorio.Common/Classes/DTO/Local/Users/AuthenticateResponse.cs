using Repositorio.Common.Classes.Enums.Users;


namespace Repositorio.Common.Classes.DTO.Local.Users
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Token { get; set; }

        public AuthenticateResponse(UserDTO user, string token)
        {
            UserId = user.UserId;
            Username = user.Username;
            Email = user.Email;
            Token = token;
        }
    }
}
