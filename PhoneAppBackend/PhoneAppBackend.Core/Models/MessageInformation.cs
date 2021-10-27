using PhoneAppBackend.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.Models
{
   public class MessageInformation : BaseEntity
    {

        public int MessageId { get; set; }

        public DateTime SentDateTime { get; set; }

        public string TwilioConfirmation { get; set; }

        public string TwilioMessage { get; set; }
    }
}
