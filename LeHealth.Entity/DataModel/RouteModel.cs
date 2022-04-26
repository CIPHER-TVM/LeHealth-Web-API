using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RouteModel
    {
        public int RouteId { get; set; }
        public string RouteDesc { get; set; }
        public string RouteCode { get; set; }
        public bool Active { get; set; }
        public string BlockReason { get; set; }
        public int SortOrder { get; set; }
        public int BranchId { get; set; }
    }
}
