using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantBaseCostModel
    {
        public int ConsultantId { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int EntryId { get; set; }
        public float BaseCost { get; set; }
        public string CPTCode { get; set; }
    }
    public class ConsultantBaseCostModelAll: ConsultantBaseCostModel
    {
        public int ConsultantId { get; set; }
    }
}
