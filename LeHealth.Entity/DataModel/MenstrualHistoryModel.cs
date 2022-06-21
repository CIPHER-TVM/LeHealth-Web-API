using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class MenstrualHistoryModel
    {
        public int Mid { get; set; } 
        public string Menarche { get; set; }
        public string Cycle { get; set; }
        public string Lmp { get; set; }
        public string Flow { get; set; }
        public string Contraception { get; set; }
        public string PapSmear { get; set; }
        public string Memogram { get; set; }
        public string ObstertrichHistory { get; set; }
        //
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public int ShowAll { get; set; }
        public string VisitDate { get; set; }
    }
}
