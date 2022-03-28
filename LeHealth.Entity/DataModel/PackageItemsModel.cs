using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PackageItemsModel
    {
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemName { get; set; }
        public int groupId { get; set; }
        public object groupCode { get; set; }
        public int rate { get; set; }
        public int quantity { get; set; }
    }
}
