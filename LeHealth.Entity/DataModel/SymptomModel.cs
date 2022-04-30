using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SymptomModel
    {
        public int SymptomId { get; set; }
        public string SymptomDesc { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; } 
    }
    public class SymptomModelAll : SymptomModel
    {
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
