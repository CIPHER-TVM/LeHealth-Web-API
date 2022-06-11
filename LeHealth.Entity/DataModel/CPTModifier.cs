using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CPTModifierModel
    {
        public int Id { get; set; }
        public string CPTModifier { get; set; }
        public string CPTDescription { get; set; }
        public bool IsDisplayed { get; set; }
    }
    public class CPTModifierAll : CPTModifierModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        
    }
}
