using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PhysicalExaminationModel
    {
        public int PEId { get; set; }
        public string Constitution { get; set; }
        public string Gastrointestinial { get; set; }
        public string Genitourinary { get; set; }
        public string Eyes { get; set; }
        public string ENT { get; set; }
        public string Neck { get; set; }
        public string Skin { get; set; }
        public string Breast { get; set; }
        public string Respiratory { get; set; }
        public string Muscleoskle { get; set; }
        public string Psychiarty { get; set; }
        public string Cardiovascular { get; set; }
        public string Neurological { get; set; }
        public string Hemotology { get; set; }
        public string Thyroid { get; set; }
        public string Abdomen { get; set; }
        public string Pelvis { get; set; }
        public string Others { get; set; }
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public int ShowAll { get; set; } 
    }
}
