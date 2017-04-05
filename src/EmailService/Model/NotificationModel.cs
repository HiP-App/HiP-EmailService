using System;
using System.ComponentModel.DataAnnotations;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace PaderbornUniversity.SILab.Hip.EmailService.Model
{
    public class NotificationModel
    {
        [Required]
        public string Recipient { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public string Updater { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Action { get; set; }

   }
}
