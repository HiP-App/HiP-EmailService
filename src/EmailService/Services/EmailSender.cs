using System.Globalization;
using PaderbornUniversity.SILab.Hip.EmailService.Utility;
using MailKit.Net.Smtp;
using MimeKit;
using PaderbornUniversity.SILab.Hip.EmailService.Model;
using System.IO;

namespace PaderbornUniversity.SILab.Hip.EmailService.Services
{
    public class EmailSender
    {
        private static string TemplateDir { get; } = "Templates";
        private static string InvitationTemplate { get; } = Path.Combine(TemplateDir, "invation-email.html");
        private static string NotificationTemplate { get; } = Path.Combine(TemplateDir, "notification-email.html");

        private readonly EmailConfig _emailConfig;

        public EmailSender(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        private void SendMail(string recipient, string subject, string content)
        {
            SendMail(new EmailModel() { Recipient = recipient, Content = content, Subject = subject });
        }

        public void SendMail(EmailModel mail)
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
                    client.Authenticate(smtp.User, smtp.Password);

                client.Send(message);
                client.Disconnect(true);
            }
        }
        public void Invite(InvitationModel invitationModel)
        {
            var bodyHtml = File.ReadAllText(InvitationTemplate);
            bodyHtml = bodyHtml.Replace(@"{email}", invitationModel.Recipient);

            SendMail(invitationModel.Recipient, invitationModel.Subject, bodyHtml);
        }

        public void Notify(NotificationModel notification)
        {
            var bodyHtml = File.ReadAllText(NotificationTemplate);
            bodyHtml = bodyHtml.Replace(@"{topic}", notification.Topic);
            bodyHtml = bodyHtml.Replace(@"{updater}", notification.Updater);
            bodyHtml = bodyHtml.Replace(@"{date}", notification.Date.ToString(CultureInfo.InvariantCulture));
            bodyHtml = bodyHtml.Replace(@"{action}", notification.Action);

            SendMail(notification.Recipient, notification.Subject, bodyHtml);
        }
    }
}
