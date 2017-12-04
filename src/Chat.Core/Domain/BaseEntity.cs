using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public bool? IsEnable { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
