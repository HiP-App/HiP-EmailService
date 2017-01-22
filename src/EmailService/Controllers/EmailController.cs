using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailService.Model;
using EmailService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmailService.Controllers
{
    [Produces("application/json")]
    [Route("Email")]
    public class EmailController : Controller
    {
        private readonly EmailSender _emailSender;
        private readonly ILogger Logger;

        public EmailController(EmailSender emailSender, ILoggerFactory loggerFactory)
        {
            _emailSender = emailSender;
            Logger = loggerFactory.CreateLogger<EmailController>();
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 503)]
        public IActionResult Post([FromBody]EmailModel email)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _emailSender.SendMail(email);
            }
            //something went wrong when sending email
            catch (MailKit.Net.Smtp.SmtpCommandException smtpError)
            {
                Logger.LogDebug(smtpError.ToString());
                return ServiceUnavailable();
            }


            return Accepted();
        }

        private static StatusCodeResult ServiceUnavailable() { return new StatusCodeResult(503); }
    }
}
