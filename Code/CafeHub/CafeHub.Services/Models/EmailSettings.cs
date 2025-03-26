using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CafeHub.Services.Interfaces;
using Microsoft.Extensions.Options;
namespace CafeHub.Services.Models
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FromEmail { get; set; } = string.Empty;
        public string FromName { get; set; } = string.Empty;
        public bool EnableSsl { get; set; } = true;
    }
}
