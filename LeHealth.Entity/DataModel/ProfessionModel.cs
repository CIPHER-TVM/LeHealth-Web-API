using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ProfessionModel
    {
        public int ProfId { get; set; }
        public string ProfName { get; set; }
        public int ProfGroup { get; set; } 
        public int UserId { get; set; } 
        public int Active { get; set; } 
        public string BlockReason { get; set; }  
    }
}
