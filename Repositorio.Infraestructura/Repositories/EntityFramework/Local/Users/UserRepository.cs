using Repositorio.Infraestructura.Repositories.Database.Context;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Infraestructura.Repositories.EntityFramework.Local.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void DeleteUser(UserEntity User)
        {
            throw new NotImplementedException();
        }

        public UserEntity getUserByEmail(string Email)
        {
            return _context.Users.Where(x => x.Email.Trim() == Email.Trim()).FirstOrDefault();
        }

        public UserEntity GetUserbyId(int id)
        {
            return _context.Users.Find(id);
        }

        public UserEntity RegisterUser(UserEntity User)
        {
            _context.Users.Add(User);
            SaveChanges();
            return User;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public UserEntity UpdateUser(UserEntity User)
        {
            throw new NotImplementedException();
        }


    }
}
