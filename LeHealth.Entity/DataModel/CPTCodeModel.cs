using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CPTCodeModel
    {
        public int CPTCodeId { get; set; }
        public string CPTCode { get; set; }
        public string CPTDesc { get; set; }
        public int BranchId { get; set; }
    }
    public class CPTCodeModelAll: CPTCodeModel
    {
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; } 
    }
}
