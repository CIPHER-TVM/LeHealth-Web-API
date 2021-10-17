using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public  class AppointmentModel
    {
        public Int32 ConsultantId { get; set; }
        public string AppDate { get; set; }

        public Int32 DeptId { get; set; }
    }
}
