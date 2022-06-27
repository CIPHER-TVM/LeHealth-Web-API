using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class VitalSignEMRModel
    {
        public int Eid { get; set; }
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int PatientId { get; set; }
    } 
}
