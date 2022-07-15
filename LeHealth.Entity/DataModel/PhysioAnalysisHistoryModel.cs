using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PhysioAnalysisHistoryModel
    {
        public int Id { get; set; }
        public string OccupationalHistory { get; set; }
        public string HazardExposureHistory { get; set; }
        public string FamilyMedicalHistory { get; set; }
        public string VaccinationHistory { get; set; }
        public string PastMedicalHistory { get; set; }
        public string AllergyHistory { get; set; }
        public string SocialHistory { get; set; }
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public List<GMQuestionModel> GmQuestionList { get; set; }

    }
    public class GMQuestionModel
    {
        public int GMQuestionId { get; set; } 
        public string GMQuestion { get; set; }
        public int GMAnswer { get; set; }
        public string Notes { get; set; }
    }
}
