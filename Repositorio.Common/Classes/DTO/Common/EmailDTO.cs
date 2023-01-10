
namespace Repositorio.Common.Classes.DTO.Common
{
    public class EmailDTO
    {
        public List<string> To { get; set; } = new List<string>();
        public List<string> Cc { get; set; } = new List<string>();
        public List<string> Bcc { get; set; } = new List<string>();
        public string Subject { get; set; } = String.Empty;
        public string HtmlContent { get; set; } = String.Empty;
    }
}
