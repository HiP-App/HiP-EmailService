using PaderbornUniversity.SILab.Hip.EmailService.Model;
using PaderbornUniversity.SILab.Hip.EmailService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PaderbornUniversity.SILab.Hip.EmailService.Controllers
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

        /// <summary>
        /// Send a email defined in the EmailModel.
        /// </summary>
        /// <param name="email">EmailModel to send</param>
        /// <response code="202">Email was send</response>
        /// <response code="400">Bad Request</response>
        /// <response code="503">Service Unavailable</response>
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

        /// <summary>
        /// Send a Notification.
        /// </summary>
        /// <param name="notificationModel">Notification to send</param>
        /// <response code="202">Email was send</response>
        /// <response code="400">Bad Request</response>
        /// <response code="503">Service Unavailable</response>
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

        /// <summary>
        /// Send a Invitation defined in the InvitationModel.
        /// </summary>
        /// <param name="invitation">Invitation to send</param>
        /// <response code="202">Email was send</response>
        /// <response code="400">Bad Request</response>
        /// <response code="503">Service Unavailable</response>
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
