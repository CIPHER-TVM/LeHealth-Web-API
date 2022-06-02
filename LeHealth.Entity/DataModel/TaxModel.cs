using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TaxModel
    {
        public int TaxId { get; set; }
        public string TaxDesc { get; set; }
        public float TaxPcnt { get; set; }
        public int HeadId { get; set; }
        public string HeadDesc { get; set; } 
        public int IsDisplayed { get; set; }
        public string IsApplied { get; set; } //For ServiceItem Tax
    }
    public class TaxModelAll : TaxModel
    {
        public int ItemId { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }

    }
}
