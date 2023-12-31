﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
namespace Pustok_DbStructure.Email
{
    public class MailService:IMailService
    {
        private readonly MailSettings _mailsettings;
        public MailService(IOptions<MailSettings> mailsettings)
        {
             _mailsettings = mailsettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailsettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailsettings.Mail, _mailsettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
