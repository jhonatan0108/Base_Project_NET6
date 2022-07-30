using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Local.Users;
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
        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            var response = _userService.Authenticate(request);
            return Ok(response);
        }

    }
}
