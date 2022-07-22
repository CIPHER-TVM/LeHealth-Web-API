using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ServiceOrderModel
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }
        public int ConsultationId { get; set; }
        public string PackageNo { get; set; }
        public int PackId { get; set; }
        public int OrderDetId { get; set; }
        public int ItemId { get; set; }
        public int SerialNo { get; set; }
        public int LocationId { get; set; }
        public string Status { get; set; }
        public string CancelReason { get; set; }
        public string TestNo { get; set; }
        public int PayStatus { get; set; }
        public string PayVoucherNo { get; set; }
        public string RequestStatus { get; set; }
        public string FillerOrderNo { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int PerStaffId { get; set; }
        public string Remarks { get; set; }
        public string ToothNo { get; set; }
        public string PerLocation { get; set; }
        public string UnlistedCodeValue { get; set; }
        public int Branchid { get; set; }
        public int TransId { get; set; }
        public string ItmDiscRemarks { get; set; }
        public int IcdLabelId { get; set; }        
        public string ItemName { get; set; }
        public bool Selected { get; set; }
        public int LoginUserId { get; set; }
        public int SessionId { get; set; }
        public List<ServiceOrderDetailsModel> ServiceorderList { get; set; }
    }
    public class ServiceAutoInitiateModel:ServiceOrderModel
    {
        public string GroupTypeName { get; set; }
        public string GroupName { get; set; }
       // public string ItemName { get; set; }
        public int STypeId { get; set; }
        public int SPointId { get; set; }
        public int InvestgnId { get; set; }
        public string InvestgnNo { get; set; }
    }
    public class ServiceOrderDetailsModel
    {
        public int OrderDetId { get; set; }
        public int PerStaffId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Remarks { get; set; }
        public string ToothNo { get; set; }
        public string PerLocation { get; set; }
        public string UnlistedCodeValue { get; set; }
        public int LoginUserId { get; set; }
        public int SessionId { get; set; }
        public int IcdLabelId { get; set; }
        public List<CptmodifierModel> CptModifierList { get; set; }
    }
    public class CptmodifierModel
    {
        public int CPTModifierId { get; set; }
    }
}
