using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultationModel
    {
        public bool EnableConsultation { get; set; }
        public String TokenNO { get; set; }
        public String PatientName { get; set; }
        public int? TimeNo { get; set; }
        public String RegNo { get; set; }
        public String Sponsor { get; set; }
        public int? ConsultationId { get; set; }
        public int? AppId { get; set; }
        public String ConsultDate { get; set; }
        public int? ConsultantId { get; set; }
        public int? PatientId { get; set; }
        public String OtherReasonForVisit { get; set; }
        public String Gender { get; set; }
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
        public String RetDesc { get; set; }
        public int? RetSeqNo { get; set; }
        public String Status { get; set; }
        public String Consultant { get; set; }
        public String ConsultType2 { get; set; }
        public String PIN { get; set; }
        public String Mobile { get; set; }
        public String Telephone { get; set; }
        public String Address { get; set; }
        public Int32 DeptId { get; set; }
        public String FromDate { get; set; }
        public String ToDate { get; set; }
        public String CancelReason { get; set; }
        public List<RegSymptomsModel> Symptoms { get; set; }
        public ConsultationModel()
        {

        }
    }
}
