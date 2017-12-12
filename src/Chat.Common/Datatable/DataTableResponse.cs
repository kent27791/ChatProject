using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Common.Datatable
{
    public class DataTableResponse<T>
    {
        public DataTableRequest Page { get; set; }

        public List<T> Data { get; set; }
    }
}
