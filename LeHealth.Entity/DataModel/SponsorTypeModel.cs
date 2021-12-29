using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorTypeModel
    {
        public int STypeId { get; set; }
        public string STypeDesc { get; set; } 
        public int Active { get; set; } 
        public string BlockReason { get; set; }  
    }
}
