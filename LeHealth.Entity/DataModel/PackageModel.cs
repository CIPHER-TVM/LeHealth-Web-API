using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PackageModel
    {
        public int PackId { get; set; }
        public string PackDesc { get; set; }
        public string EffectFrom { get; set; }
        public string EffectTo { get; set; }
        public float PackAmount { get; set; }
        public string Remarks { get; set; }
        public List<ItemRateModel> ItemRateList { get; set; }  
    }
    public class PackageModelAll : PackageModel
    {
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }

}
