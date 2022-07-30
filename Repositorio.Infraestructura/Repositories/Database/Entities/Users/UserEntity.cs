using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repositorio.Infraestructura.Repositories.Database.Entities.Users
{
    public class UserEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }
        public int MaxAttempts { get; set; }
        public int IdStatus { get; set; }
        public int IdRole { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = new byte[512];
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; } = new byte[512];


    }
}
