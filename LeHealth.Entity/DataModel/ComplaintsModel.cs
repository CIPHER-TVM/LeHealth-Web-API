using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ComplaintsModel
    {
        public int ComplaintId { get; set; }
        public string ChiefComplaint { get; set; }
        public string ComplaintOf { get; set; }
        public string Site { get; set; }
        public string SymptomSince { get; set; }
        public int Severity { get; set; }
        public int Course { get; set; }
        public int Symptom { get; set; }
        public int TobaccoStatus { get; set; }
        public string AssociatedSigns { get; set; }
        public string ChiefComplaintsBy { get; set; }
        public int PainScale { get; set; }
        public int UserId { get; set; } 
    }
}
