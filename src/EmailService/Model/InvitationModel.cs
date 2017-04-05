using System.ComponentModel.DataAnnotations;

namespace PaderbornUniversity.SILab.Hip.EmailService.Model
{
    public class InvitationModel
    {
        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Subject { get; set; }
    }
}
