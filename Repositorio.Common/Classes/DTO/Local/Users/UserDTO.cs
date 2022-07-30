using Repositorio.Common.Classes.Enums.Users;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repositorio.Common.Classes.DTO.Local.Users
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int MaxAttempts { get; set; } = 10;
        public string Role { get; set; }=String.Empty;

        [JsonIgnore]
        public int IdRole { get; set; } = 0;
    }
}
