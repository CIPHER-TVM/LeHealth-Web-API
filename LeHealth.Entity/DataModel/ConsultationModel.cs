using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultationModel
    {
        public bool EnableConsultation { get; set; }
        public string TokenNO { get; set; }
        public string PatientName { get; set; }
        public int? TimeNo { get; set; }
        public string RegNo { get; set; }
        public string Sponsor { get; set; }
        public int? ConsultationId { get; set; }
        public int? AppId { get; set; }
        public string ConsultDate { get; set; }
        public int? ConsultantId { get; set; }
        public int? PatientId { get; set; }
        public string Symptoms { get; set; }
        public int? ConsultType { get; set; }
        public float ConsultFee { get; set; }
        public float EmerFee { get; set; }
        public int Emergency { get; set; }
        public Int32 ItemId { get; set; }
        public int? AgentId { get; set; }
        public int? LocationId { get; set; }
        public int? LeadAgentId { get; set; }
        public int? InitiateCall { get; set; }
        public int? UserId { get; set; }
        public int? SessionId { get; set; }
        public int? RetVal { get; set; }
        public string RetDesc { get; set; }
        public int? RetSeqNo { get; set; }
        public string Status { get; set; }
        public string Consultant { get; set; }
        public string ConsultType2 { get; set; }
        public string PIN { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
}
