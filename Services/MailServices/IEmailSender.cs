using System.Threading.Tasks;

namespace MyBlog.Services.MailServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendSmsAsync(string number, string message);
    }
}