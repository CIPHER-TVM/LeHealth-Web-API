using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class FrequencyModel
    {
        public int FreqId { get; set; }
        public string FreqDesc { get; set; }
        public int FreqValue { get; set; }
        public int BranchId { get; set; }
    }
}
