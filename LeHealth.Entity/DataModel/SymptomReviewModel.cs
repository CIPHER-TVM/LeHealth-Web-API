using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SymptomReviewModel
    {
        public int SRMId { get; set; }
        public string Constitutional { get; set; }
        public string Respiratory { get; set; }
        public string Phychiatry { get; set; }
        public string Gastrointestinial { get; set; }
        public string Hemotology { get; set; }
        public string Neurological { get; set; }
        public string Skin { get; set; }
        public string Cardiovascular { get; set; }
        public string Endocrinal { get; set; }
        public string Genitourinary { get; set; }
        public string ENT { get; set; }
        public string Immunological { get; set; }
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public int ShowAll { get; set; }
    }
}
