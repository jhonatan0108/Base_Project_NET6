using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Repositorio.Common.Classes.DTO.Helpers;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Domain.Services.Local.Users;

namespace Repositorio.Domain.Services.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            context.Items["UserDTO"] = null;
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["UserDTO"] = userService.GetUserbyId(userId.Value);
            }

            await _next(context);
        }
    }
}
