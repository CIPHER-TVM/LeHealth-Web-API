using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientHistoryEMRModel
    {
        public int Id { get; set; }
        public string PastMedicalHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string SocialHistory { get; set; }
        public string CurrentMedication { get; set; }
        public string Immunization { get; set; }
        public string CancerHistory { get; set; }
        public string SurgicalHistory { get; set; }
        public string Others { get; set; }
        public int TobaccoStatus { get; set; }
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }
    }
}
