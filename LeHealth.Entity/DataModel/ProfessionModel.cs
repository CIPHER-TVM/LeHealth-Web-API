using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ProfessionModel
    {
        public int ProfId { get; set; }
        public string ProfName { get; set; }
        public string ProfCode { get; set; } 
        public int ProfGroup { get; set; }
        public bool IsDisplayed { get; set; }
    }
    public class ProfessionModelAll : ProfessionModel
    {
        public int BranchId { get; set; } 
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        
    }
}
