using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantBaseCostModel
    {
        public int ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public List<ItemRateDetailModel> ItemRates { get; set; }

    }
    public class ItemRateDetailModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string BaseCost { get; set; }
    }
    public class ConsultantBaseCostModelAll : ConsultantBaseCostModel
    {
        public List<ItemRateInput> itemRateIP { get; set; } 
        public int BranchId { get; set; }
    }
    public class ItemRateInput
    {
        public int ItemId { get; set; }
        public float BaseCost { get; set; }
    }
}
