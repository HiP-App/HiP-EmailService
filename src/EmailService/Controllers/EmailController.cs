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
        private readonly ILogger _logger;

        public EmailController(EmailSender emailSender, ILoggerFactory loggerFactory)
        {
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<EmailController>();
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
                _logger.LogDebug(smtpError.ToString());
                return ServiceUnavailable();
            }
            return Accepted();
        }

        [HttpPost("Notification")]
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 503)]
        public IActionResult PostNotification([FromBody]NotificationModel notificationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _emailSender.Notify(notificationModel);
            }
            //something went wrong when sending email
            catch (MailKit.Net.Smtp.SmtpCommandException smtpError)
            {
                _logger.LogDebug(smtpError.ToString());
                return ServiceUnavailable();
            }
            return Accepted();
        }

        [HttpPost("Invitation")]
        [ProducesResponseType(typeof(void), 202)]
        [ProducesResponseType(typeof(void), 400)]
        [ProducesResponseType(typeof(void), 503)]
        public IActionResult PostInvitation([FromBody]InvitationModel invitation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _emailSender.Invite(invitation);
            }
            //something went wrong when sending email
            catch (MailKit.Net.Smtp.SmtpCommandException smtpError)
            {
                _logger.LogDebug(smtpError.ToString());
                return ServiceUnavailable();
            }
            return Accepted();
        }

        private static StatusCodeResult ServiceUnavailable() { return new StatusCodeResult(503); }
    }
}
