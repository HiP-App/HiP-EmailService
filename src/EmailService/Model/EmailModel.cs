using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Model
{
    public class EmailModel
    {
        public string Recipient { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

    }
}
