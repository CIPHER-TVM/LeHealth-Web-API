using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public  class ConsultationModel
    {
        public string TokenNO { get; set; }
        public string PatientName { get; set; }
        public int TimeNo { get; set; }
        public string RegNo { get; set; }
        public string Sponsor { get; set; }
        public int ConsultationId { get; set; }
        public int AppId { get; set; }
        public DateTime ConsultDate { get; set; }
        public int ConsultantId { get; set; }
        public int PatientId { get; set; }
        public string Symptoms { get; set; }
        public int ConsultType { get; set; }
        public float ConsultFee { get; set; }
        public float EmerFee { get; set; }
         public int Emergency { get; set; }
        public int ItemId { get; set; }
        public int AgentId { get; set; }
        public int LocationId { get; set; }
        public int LeadAgentId { get; set; }
        public bool InitiateCall { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int RetVal { get; set; }
        public string RetDesc { get; set; }
        public int RetSeqNo { get; set; }
    public string Status { get; set; }

    }
}
