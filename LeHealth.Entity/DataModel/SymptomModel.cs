using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SymptomModel
    {
        public int SymptomId { get; set; }
        public String SymptomDesc { get; set; }
        public int Active { get; set; }
        public int UserId { get; set; }
        public String BlockReason { get; set; }
    }
}
