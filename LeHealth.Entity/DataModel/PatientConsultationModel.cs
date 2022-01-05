using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientConsultationModel
    {
        public string RegNo { get; set; }
        public string PatientName { get; set; }
        public string NationalId { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int ConsultationId { get; set; } 
        public int ConsultantId { get; set; } 
        public string ReasonForVisit { get; set; }
        public List<RegSymptomsModel> Symptoms { get; set; }
    }
}
