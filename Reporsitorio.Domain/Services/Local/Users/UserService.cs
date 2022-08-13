using AutoMapper;
using Microsoft.Extensions.Configuration;
using Repositorio.Common.Classes.DTO.Helpers;
using Repositorio.Common.Classes.DTO.Local.Users;
using Repositorio.Common.Classes.Enums.Users;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Infraestructura.Repositories.Database.Entities.Users;
using Repositorio.Infraestructura.Repositories.EntityFramework.Local.Users;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Repositorio.Domain.Services.Local.Users
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IJwtUtils _jwtUtils;

        public UserService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration, IJwtUtils jwtUtils)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
            _jwtUtils = jwtUtils;
        }

        public UserDTO RegisterUser(UserDTO User)
        {

            #region Valida si el usuario ya existe 
            UserEntity userEntity = _userRepository.getUserByEmail(User.Email);
            if (userEntity != null)
                throw new ValidationException("El Usuario ya se encuentra registrado en el sistema. ");
            #endregion


            UserEntity user = _mapper.Map<UserEntity>(User);
            CreatePasswordhash(User.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Password = new CipherText(_configuration).EncryptString(User.Password);
            user.IdStatus = (int)StatusEnum.Active;

            if (User.Role.Contains(RoleEnum.Admin.ToString()) || User.Role.Contains(RoleEnum.User.ToString()))
            {
                user.IdRole = (int)Enum.Parse(typeof(RoleEnum), User.Role.ToString());
            }
            else
            {
                user.IdRole = (int)RoleEnum.User;
            }

            user = _userRepository.RegisterUser(user);
            return _mapper.Map<UserDTO>(user);
        }

        private bool IsAuthenticated(UserDTO User, string password)
        {
            bool response = false;
            UserEntity userEntity = _userRepository.getUserByEmail(User.Email);
            if (userEntity != null)
            {
                response = VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt);
            }
            return response;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private void CreatePasswordhash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordUser(UserEntity user, string pass)
        {
            return user.Password == new CipherText(_configuration).EncryptString(pass);
        }
        public string GenerateToken(UserDTO User)
        {
            UserEntity userEntity = _userRepository.getUserByEmail(User.Email);
            return _jwtUtils.GenerateJwtToken(userEntity);
        }

        public AuthenticateResponse GetToken(AuthenticateRequest model)
        {
            UserEntity user = _userRepository.getUserByEmail(model.Email);

            // validate
            if (user == null || !IsAuthenticated(_mapper.Map<UserDTO>(user), model.Password))
                throw new ValidationException("Username or password is incorrect");

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new AuthenticateResponse(_mapper.Map<UserDTO>(user), jwtToken);
        }

        public UserDTO LoginUser(AuthenticateRequest model)
        {
            UserEntity user = _userRepository.getUserByEmail(model.Email);
            if (user != null)
            {
                if (user.MaxAttempts > 0)
                {
                    if (VerifyPasswordUser(user, model.Password))
                    {
                        return _mapper.Map<UserDTO>(user);
                    }
                    else
                    {
                        //update attemps 
                        user.MaxAttempts = user.MaxAttempts - 1;
                        _userRepository.UpdateUser(user);
                        throw new ValidationException("Username or password is incorrect");
                    }
                }
                else
                {
                    user.IdStatus = (int)StatusEnum.Inactive;
                    _userRepository.UpdateUser(user);
                    throw new ValidationException("Your account has been blocked due to failed attempts.");
                }
            }
            else
            {
                throw new ValidationException("User not found");
            }
        }

        public UserDTO GetUserbyId(int id)
        {
            return _mapper.Map<UserDTO>(_userRepository.GetUserbyId(id));
        }

        public List<UserDTO> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(_userRepository.GetAll());
        }
    }
}
