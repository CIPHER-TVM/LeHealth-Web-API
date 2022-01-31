using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class LeadAgentModel
    {
        public int LeadAgentId { get; set; }
        public String Name { get; set; }
        public String ContactNo { get; set; }
        public float CommisionPercent { get; set; }
        public int Active { get; set; } 
        public String BlockReason { get; set; }  
    }
}
