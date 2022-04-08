using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class TimerModel
    {
        public string Title { get; set; }
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public int ConsultantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
