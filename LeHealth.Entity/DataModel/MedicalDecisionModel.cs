using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class MedicalDecisionModel
    {
        public int MDId { get; set; }
        public string LabOrder { get; set; }
        public string RadiologyOrder { get; set; }
        public string TreatmentOrder { get; set; }
        public string OldMedicalRecord { get; set; }
        public string ReferToPhysician { get; set; }
        public string DifferencialDiagnosis { get; set; }
        public string Eligibility { get; set; }
        //Common
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public int ShowAll { get; set; }
        public string VisitDate { get; set; }
    }
}
