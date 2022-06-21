using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PlanAndProcedureModel
    {
        public int PapId { get; set; }
        public string PlanAndProcedure { get; set; }
        public string PatientInstruction { get; set; }
        public string FollowUp { get; set; }
        //Common
        public int VisitId { get; set; }
        public int UserId { get; set; }
        public int PatientId { get; set; }
        public int ShowAll { get; set; }
        public string VisitDate { get; set; }
    }
}
