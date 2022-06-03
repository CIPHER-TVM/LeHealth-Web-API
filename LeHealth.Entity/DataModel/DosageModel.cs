using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DosageModel
    {
        public int DosageId { get; set; }
        public string DosageDesc { get; set; }
        public bool Active { get; set; }
        public double DosageValue { get; set; }
        public int IsDeleted { get; set; }
        public int ZoneId { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class DosageModelAll : DosageModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
      
    }
}
