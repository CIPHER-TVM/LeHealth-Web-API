using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorFormModel
    {
        public int SFormId { get; set; }
        public string SFormName { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; } 
    }
}
