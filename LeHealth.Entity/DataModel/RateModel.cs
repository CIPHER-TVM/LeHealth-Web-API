using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RateModel
    {
        public int RGroupId { get; set; }
        public string RGroupName { get; set; }
        public float Rate { get; set; }
        public int ItemId { get; set; }
    }
    public class RateModelAll : RateModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
