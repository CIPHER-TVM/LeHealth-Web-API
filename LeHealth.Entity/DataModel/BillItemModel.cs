using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public  class BillItemModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public string ItemCode { get; set; }        
        public int ItemId { get; set; }
        public float DiscAmount { get; set; }
        public int TreatNos { get; set; }
        public int ItemSelected { get; set; }
        public string ItemName { get; set; }
        public float Rate { get; set; }
        public string CPTDesc { get; set; }
        public int CommItemsOnly { get; set; }
        public int SPointId { get; set; }
        public int ServiceTtems { get; set; }
        public int BranchId { get; set; }
        public int ShowAll { get; set; }
    }
}
