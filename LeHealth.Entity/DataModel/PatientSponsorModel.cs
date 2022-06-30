using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientSponsorModel
    {
        public int SponsorId { get; set; }
        public string SponsorName { get; set; }
        public int CreditId { get; set; }
        public string OpenDate { get; set; }
        public string RefNo { get; set; }
        public float Limit { get; set; }
        public float Enjoyed { get; set; }
        public float Available { get; set; }
        public float Deduction { get; set; }
        public float CoPayment { get; set; }
        public string PolicyNo { get; set; }
         public string AgentName { get; set; }
         public int PatientId { get; set; }

       
    }
}
