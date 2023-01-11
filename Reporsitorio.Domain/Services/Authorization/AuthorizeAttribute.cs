using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Repositorio.Common.Classes.DTO.Local.Users;
using Repositorio.Common.Classes.Enums.Users;

namespace Repositorio.Domain.Services.Authorization
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<RoleEnum> _roles;

        public AuthorizeAttribute(params RoleEnum[] roles)
        {
            _roles = roles ?? new RoleEnum[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            var user = (UserDTO)context.HttpContext.Items["UserDTO"];
            if (user == null || (_roles.Any() && !_roles.Contains((RoleEnum)Enum.Parse(typeof(RoleEnum), user.Role.ToString()))))
            {
                context.Result = new JsonResult(new { message = "Unauthorized", StatusCode = StatusCodes.Status401Unauthorized }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
