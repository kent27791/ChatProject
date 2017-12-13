using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Common.Datatable
{
    public class DataTableRequest
    {
        public int Count { get; set; }

        public int Limit { get; set; }

        public int Offset { get; set; }
    }
}
