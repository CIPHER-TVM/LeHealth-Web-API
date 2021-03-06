using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ItemsByTypeModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int GroupId { get; set; }
        public string GroupCode { get; set; }
        public float Rate { get; set; }
        public int Quantity { get; set; }
        public int BranchId { get; set; } 
        public int ShowAll { get; set; }  
    }
}
