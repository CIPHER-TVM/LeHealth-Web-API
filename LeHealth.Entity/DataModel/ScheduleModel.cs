using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ScheduleModel
    {
        public int ScheduleId { get; set; }
        public int ConsultantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
    }
    public class ScheduleModelAll : ScheduleModel
    {
        public int BranchId { get; set; }
    }
}

