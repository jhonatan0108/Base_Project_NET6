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

        [HttpPost, DisableRequestSizeLimit]
        [Route("Send")]
        public IActionResult SendEmail([FromForm] EmailDTO request)
        {
            var file = Request.Form.Files.Count() > 0 ? Request.Form.Files[0] : null;
            _serviceEmail.SendEmail(request, file);
            return Ok();
        }
    }
}
