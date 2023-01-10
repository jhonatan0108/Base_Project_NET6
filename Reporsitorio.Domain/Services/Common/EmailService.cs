using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Repositorio.Common.Classes.DTO.Common;
using System.Net;

namespace Repositorio.Domain.Services.Common
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly IFileManagerService _fileManagerService;

        public EmailService(IConfiguration configuration, IFileManagerService fileManagerService)
        {
            _configuration = configuration;
            _fileManagerService = fileManagerService;
        }

        public void SendEmail(EmailDTO request, IFormFile fileAttachment = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_configuration["Configuration:NombreAPP"], _configuration["Configuration:Email:EmailUsername"]));
            foreach (string item in request.To)
            {
                email.To.Add(MailboxAddress.Parse(item));
            }

            foreach (string item in request.Cc)
            {
                email.Cc.Add(MailboxAddress.Parse(item));
            }

            foreach (string item in request.Bcc)
            {
                email.Bcc.Add(MailboxAddress.Parse(item));
            }

            email.Subject = request.Subject;

            var builder = new BodyBuilder();
            builder.TextBody = request.HtmlContent;

            if (fileAttachment != null)
            {
                string pathFile = _fileManagerService.SaveFileToRoute(fileAttachment);
                if (!string.IsNullOrEmpty(pathFile))
                    builder.Attachments.Add($"{pathFile}");
            }

            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Connect(_configuration["Configuration:Email:EmailHost"], int.Parse(_configuration["Configuration:Email:EmailPort"]), MailKit.Security.SecureSocketOptions.None);
            smtp.Authenticate(_configuration["Configuration:Email:EmailUsername"], _configuration["Configuration:Email:EmailPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);
            _fileManagerService.DeleteFilesToRoute();

        }
    }
}
