
using System.ComponentModel.DataAnnotations;

namespace Repositorio.Common.Classes.DTO.Local.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; } = String.Empty;

        [Required]
        public string Password { get; set; } = String.Empty;
    }
}
