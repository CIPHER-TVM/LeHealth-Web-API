using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PackageItemsModel
    {
        public int PackId { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public int groupId { get; set; }
        public object groupCode { get; set; }
        public float rate { get; set; }
        public int quantity { get; set; }
    }
}
