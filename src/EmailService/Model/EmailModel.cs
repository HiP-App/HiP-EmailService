using System.ComponentModel.DataAnnotations;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace EmailService.Model
{
    public class EmailModel
    {
        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
