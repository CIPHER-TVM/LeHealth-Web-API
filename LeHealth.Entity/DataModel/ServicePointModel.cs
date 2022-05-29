using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ServicePointModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int SPointId { get; set; }
        public string SPointName { get; set; }
        public bool Schedulable { get; set; }
        public int RoutineNos { get; set; }
        public int UrgentNos { get; set; }
        public bool Active { get; set; }
        public string BlockReason { get; set; }
        public int UserId { get; set; }

    }
    public class ServicePointModelAll : ServicePointModel
    {
        public int BranchId { get; set; }

    }
}
