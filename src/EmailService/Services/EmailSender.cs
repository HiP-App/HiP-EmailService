using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmailService.Utility;
using MailKit.Net.Smtp;
using MimeKit;
using EmailService.Model;

namespace EmailService.Services
{
    public class EmailSender
    {
        private readonly EmailConfig _emailConfig;

        public EmailSender(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public Task SendMail(EmailModel mail)
        {
            var smtp = _emailConfig.SmtpConfig;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("History in Paderborn", smtp.From));
            message.To.Add(new MailboxAddress("", mail.Recipient));
            message.Subject = mail.Subject;
            message.Body = new TextPart("html")
            {
                Text = mail.Content
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(smtp.Server, smtp.Port, smtp.WithSSL);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                if (!string.IsNullOrEmpty(smtp.Password))
                {
                    client.Authenticate(smtp.User, smtp.Password);
                }

                client.Send(message);
                client.Disconnect(true);
            }

            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

    }
}
