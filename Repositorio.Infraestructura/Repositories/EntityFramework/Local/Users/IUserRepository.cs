using Repositorio.Infraestructura.Repositories.Database.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local.Users
{
    public interface IUserRepository
    {
        UserEntity RegisterUser(UserEntity User);
        UserEntity getUserByEmail(string Email);
        UserEntity UpdateUser(UserEntity User);
        UserEntity GetUserbyId(int id);
        void DeleteUser(UserEntity User);

        void SaveChanges();
    }
}
