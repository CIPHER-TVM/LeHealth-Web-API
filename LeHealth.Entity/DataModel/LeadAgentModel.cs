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
        public String CommisionPercent { get; set; }
        public int Active { get; set; } 
    }
}
