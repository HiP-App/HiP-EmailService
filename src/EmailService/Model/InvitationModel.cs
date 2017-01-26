using System.ComponentModel.DataAnnotations;

namespace EmailService.Model
{
    public class InvitationModel
    {
        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
