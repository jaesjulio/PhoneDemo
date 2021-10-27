using PhoneAppBackend.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.Models
{
   public class Message : BaseEntity
    {

        public string ToNumber { get; set; }

        public string TextMessage { get; set; }

    }
}
