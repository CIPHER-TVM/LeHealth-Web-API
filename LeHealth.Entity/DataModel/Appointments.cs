using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public  class Appointments
    {
    public int AppId { get; set; }
        public string PatientName { get; set; }
        public string AppType { get; set; }
        public int TimeNo { get; set; }
        public int RegNo { get; set; }
        public string Status { get; set; }

    }
}
