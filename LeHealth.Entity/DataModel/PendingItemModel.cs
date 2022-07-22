using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PendingItemModel
    {
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public string ConsultantName { get; set; }
        public string OrderDate { get; set; }
        public string PatientName { get; set; }
        public string FirstName { get; set; }
        public string RegNo { get; set; }
        public string Mobile { get; set; }
        public string ResNo { get; set; }
        public int IsCancelled { get; set; }
        public List<ServiceItem> ItemData { get; set; }
    }
    public class ServiceItem
    {
        public string PayStatus { get; set; }
        public string Status { get; set; }
        public string RequestStatus { get; set; }
        public string ItemName { get; set; }
        public string OrderId { get; set; }
    }
    public class PendingItemInputData
    {
        public string OrderFromDate { get; set; }
        public string OrderToDate { get; set; }
        public string OrderNo { get; set; }
        public string RegNo { get; set; }
        public string PatientName { get; set; }
        public int ConsultantId { get; set; }
        public int IsExternalConsultant { get; set; }
        public int PatientId { get; set; }
        public int BranchId { get; set; }
    }
    public class ServiceItemModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int GroupId { get; set; }
        public int ValidityDays { get; set; }
        public int ValidityVisits { get; set; }
        public bool AllowRateEdit { get; set; }
        public bool AllowDisc { get; set; }
        public bool AllowPP { get; set; }
        public bool IsVSign { get; set; }
        public int ResultOn { get; set; }
        public int STypeId { get; set; }
        public float TotalTaxPcnt { get; set; }
        public bool AllowCommission { get; set; }
        public float CommPcnt { get; set; }
        public float CommAmt { get; set; }
        public float MaterialCost { get; set; }
        public float BaseCost { get; set; }
        public int HeadId { get; set; }
        public int SortOrder { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public bool ExternalItem { get; set; }
        public int CPTCodeId { get; set; }
        public string BlockReason { get; set; }
        public int Active { get; set; }
        public int BranchId { get; set; }
        public int DrugTypeId { get; set; }
        public int VaccineTypeId { get; set; }
        public string DefaultTAT { get; set; }
        public List<int> ItemTaxList { get; set; }
        public List<RateModel> ItemRateList { get; set; }
    }
}
