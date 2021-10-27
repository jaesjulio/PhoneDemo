using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppMobile.Models
{
    public class MessageInformation
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        public int MessageId { get; set; }

        public DateTime SentDateTime { get; set; }

        public string TwilioConfirmation { get; set; }

        public string TwilioMessage { get; set; }
    }
}
