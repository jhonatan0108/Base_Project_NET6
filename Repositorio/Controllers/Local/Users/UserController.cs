using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Local.Users;
using Repositorio.Common.Classes.Response;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Domain.Services.Local.Users;

namespace Repositorio.Controllers.Local.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(UserDTO request)
        {
            UserDTO user = _userService.RegisterUser(request);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("GenerateToken")]
        public IActionResult GenerateToken(AuthenticateRequest request)
        {
            var response = _userService.GetToken(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ResponseHandler<UserDTO> Login(AuthenticateRequest request)
        {
            ResponseHandler<UserDTO> response = new();
            response.Data = _userService.LoginUser(request);
            response.StatusCode = (int)HttpCodes.Ok;
            return response;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public ResponseHandler<List<UserDTO>> GetAll()
        {
            ResponseHandler<List<UserDTO>> response = new();
            response.Data = _userService.GetAll();
            response.StatusCode = (int)HttpCodes.Ok;
            return response;
        }
    }
}
