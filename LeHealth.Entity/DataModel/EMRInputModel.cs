using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class EMRInputModel
    {
        public int PatientId { get; set; }
        public int VisitId { get; set; }
        public int ConsultantId { get; set; } 
    }
}
