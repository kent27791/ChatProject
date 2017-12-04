using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Domain.SecurityManagement
{
    public class GroupMember : BaseEntity<int>
    {
        public string GroupName { get; set; }
    }
}
