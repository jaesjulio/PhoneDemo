using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppMobile.Models
{
   public class Message
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } 
        public DateTime? DeletedAt { get; set; }
        public string ToNumber { get; set; }

        public string TextMessage { get; set; }
    }
}
