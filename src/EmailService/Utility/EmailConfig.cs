﻿using Microsoft.Extensions.Configuration;

namespace PaderbornUniversity.SILab.Hip.EmailService.Utility
{
    public class EmailConfig
    {
        public SmtpConfig SmtpConfig { get; }

        public EmailConfig(IConfiguration configuration)
        {
            SmtpConfig = new SmtpConfig
            {
                From = configuration.GetValue<string>("SMTP_FROM"),
                Server = configuration.GetValue<string>("SMTP_SERVER"),
                Port = configuration.GetValue<int>("SMTP_PORT"),
                WithSSL = configuration.GetValue<bool>("SMTP_WITH_SSL"),
                User = configuration.GetValue<string>("SMTP_USER"),
                Password = configuration.GetValue<string>("SMTP_PASSWORD")
            };
        }
    }

    public class SmtpConfig
    {
        public string From { get; set; }
        public string Server { get; set; }
        public int Port { get; set; }
        // ReSharper disable once InconsistentNaming
        public bool WithSSL { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
