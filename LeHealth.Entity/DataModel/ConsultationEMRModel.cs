using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultationEMRModel
    {
        public int ConsultationId { get; set; }
        public string ConsultDate { get; set; }

    }
    public class ConsultationEMRModelAll : ConsultationEMRModel
    {
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public string Status { get; set; }
    }
}
