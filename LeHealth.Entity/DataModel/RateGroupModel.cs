using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RateGroupModel
    {
        public int RGroupId { get; set; }
        public String RGroupName { get; set; }
        public String Description { get; set; }
        public String EffectFrom { get; set; }
        public String EffectTo { get; set; } 
        public int Active { get; set; } 
        public int UserId { get; set; } 
        public string BlockReason { get; set; }  
    }
}
