using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class InvestigationModel
    {
        public int InvestgnId { get; set; }
        public int PatientId { get; set; }
        public int LocationId { get; set; }
        public string InvestgnNo { get; set; }
        public string InvestgnDate { get; set; }
        public int STypeId { get; set; }
        public int SPointId { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public int SessionId { get; set; }
        public int UserId { get; set; }
    }
}
