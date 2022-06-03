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
        public int IsDeleted { get; set; }
        public int ZoneId { get; set; }
        public int IsDisplayed { get; set; }
        public int BranchId { get; set; }
    }
    public class FrequencyModelAll:FrequencyModel
    {
      
        public int UserId { get; set; }
        public int ShowAll { get; set; }
    }
}
