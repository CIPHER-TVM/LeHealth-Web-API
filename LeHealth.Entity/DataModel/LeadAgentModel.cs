using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class LeadAgentModel
    {
        public int LeadAgentId { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public float CommisionPercent { get; set; }
        public int Active { get; set; } 
        public string BlockReason { get; set; }  
    }
}
