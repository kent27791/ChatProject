using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Domain.LogManagement
{
    public class SystemLog : BaseEntity<int>
    {
        public string Value { get; set; }
    }
}
