using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Domain.SecurityManagement
{
    public class Member : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
