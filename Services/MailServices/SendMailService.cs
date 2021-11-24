using System;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MyBlog.Services.MailServices
{
    public class SendMailService : IEmailSender
    {


        private readonly MailSettings mailSettings;

        private readonly ILogger<SendMailService> logger;


        // mailSetting được Inject qua dịch vụ hệ thống
        // Có inject Logger để xuất log
        public SendMailService(IOptions<MailSettings> _mailSettings, ILogger<SendMailService> _logger)
        {
            mailSettings = _mailSettings.Value;
            logger = _logger;
            logger.LogInformation($"Create SendMailService");
        }


        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail);
            message.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = htmlMessage;
            message.Body = bodyBuilder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(mailSettings.Host, mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Mail, mailSettings.Password);
                await smtp.SendAsync(message);
                logger.LogInformation("send mail to " + email);
            }

            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("Mail_Save");
                var emailsavefile = string.Format(@"Mail_Save/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailsavefile);

                logger.LogInformation("Gởi mail thất bại, mail lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
            }

            finally
            {
                smtp.Disconnect(true);
            }
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Cài đặt dịch vụ gửi SMS tại đây
            System.IO.Directory.CreateDirectory("SMS_Save");
            var emailsavefile = string.Format(@"SMS_Save/{0}-{1}.txt", number, Guid.NewGuid());
            System.IO.File.WriteAllTextAsync(emailsavefile, message);
            return Task.FromResult(0);
        }
    }
}