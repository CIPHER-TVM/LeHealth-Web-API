using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TendernModel
    {
        public int TendernId { get; set; }
        public string TendernDesc { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
    }
}
