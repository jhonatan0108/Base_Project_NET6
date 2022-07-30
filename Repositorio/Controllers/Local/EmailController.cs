using Microsoft.AspNetCore.Mvc;
using Repositorio.Common.Classes.DTO.Common;
using Repositorio.Domain.Services.Authorization;
using Repositorio.Domain.Services.Common;

namespace Repositorio.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _serviceEmail;

        public EmailController(IEmailService serviceEmail)
        {
            _serviceEmail = serviceEmail;
        }

        [HttpPost]
        [Route("Send")]
        public IActionResult SendEmail(EmailDTO request)
        {
            _serviceEmail.SendEmail(request);
            return Ok();
        }
    }
}
