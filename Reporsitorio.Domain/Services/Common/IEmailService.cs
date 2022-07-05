using Repositorio.Common.Classes.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Domain.Services.Common
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
