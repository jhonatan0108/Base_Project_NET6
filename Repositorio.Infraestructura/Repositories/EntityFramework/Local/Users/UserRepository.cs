using Microsoft.EntityFrameworkCore;
using Repositorio.Common.Classes.Enums.Users;
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

        public List<UserEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        public UserEntity getUserByEmail(string Email)
        {
            return _context.Users.Where(x => x.Email.Trim() == Email.Trim() && x.IdStatus == (int)StatusEnum.Active).FirstOrDefault();
        }

        public UserEntity GetUserbyId(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<UserEntity> RegisterUser(UserEntity User)
        {
            await _context.Users.AddAsync(User);
            SaveChanges();
            return User;
        }

        public void SaveChanges()
        {
            _context.SaveChangesAsync();
        }

        public UserEntity UpdateUser(UserEntity User)
        {
            _context.Entry(User).State = EntityState.Modified;
            SaveChanges();
            return User;
        }


    }
}
