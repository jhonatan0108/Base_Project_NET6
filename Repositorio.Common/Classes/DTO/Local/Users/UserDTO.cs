using Repositorio.Common.Classes.DTO.Local.Empresas;
using System.Text.Json.Serialization;
namespace Repositorio.Common.Classes.DTO.Local.Users
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public int IdEmpresa { get; set; }
        public EmpresasContract EmpresaUser { get; set; } = new EmpresasContract();

        public string Password { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public int MaxAttempts { get; set; } = 10;
        public string Role { get; set; } = String.Empty;

        [JsonIgnore]
        public int IdRole { get; set; } = 0;
    }
}
