
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SendEmail.Dto;
using MailKit.Net.Smtp;
using System.Net.Mail;
using System.Net.Mime;
using ContentType = MimeKit.ContentType;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Net;

namespace SendEmail.Service
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string MailTo, string subject, string body, IList<IFormFile> Attachments = null)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(MailTo),
                Subject = subject,
            };

            email.To.Add(MailboxAddress.Parse(MailTo));

            var builder = new BodyBuilder();

            if (Attachments != null)
            {
                byte[] fileByte;
                foreach (var file in Attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileByte = ms.ToArray();

                        builder.Attachments.Add(file.FileName, fileByte, ContentType.Parse(file.ContentType));
                    }
                }
            }
            // body
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            // connecting on smtpclient
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
