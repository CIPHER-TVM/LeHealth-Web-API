using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class VisitModel
    {
        public int VisitId { get; set; }
        public int ConsultantId { get; set; }
        public int ConsultationId { get; set; }
        public int PatientId { get; set; }
        public int VisitType { get; set; }
        public string VisitStartTime { get; set; }
        public string VisitEndTime { get; set; }
    }
}
