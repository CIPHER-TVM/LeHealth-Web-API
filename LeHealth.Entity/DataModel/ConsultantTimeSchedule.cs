using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantTimeScheduleMaster
    {
        public int ScheMid { get; set; }
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }
        public int AlldaySameFlag { get; set; }
        public int UserId { get; set; }
        public List<ConsultantTimeSchedule> TimeSchedules { get; set; }

    }
    public class ConsultantTimeSchedule
    {
        public int Scheid { get; set; }
        public int Consultantd { get; set; }
        public int BranchId { get; set; }
        public int DayId { get; set; }
        public int ScheMid { get; set; }
        public string FromHour { get; set; }
        public string FromMinute { get; set; }
        public string FromTime { get; set; }
        public string FromAmPm { get; set; }
        public string ToHour { get; set; }
        public string ToMinute { get; set; }
        public string ToTime { get; set; }
        public string ToAmPm { get; set; }
        public int UserId { get; set; }

    }
}
