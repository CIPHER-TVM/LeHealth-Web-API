using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultationEMRModel
    {
        public string Status { get; set; }
        public int ConsultantId { get; set; }
    }
    public class ConsultationEMRModelAll : ConsultationEMRModel
    {
       
    }
}
