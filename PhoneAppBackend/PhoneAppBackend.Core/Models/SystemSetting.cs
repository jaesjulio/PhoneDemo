using PhoneAppBackend.Core.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.Models
{
    public class SystemSetting : BaseEntity
    {
        public string Code { get; set; }

        public string Value { get; set; }
    }
}
