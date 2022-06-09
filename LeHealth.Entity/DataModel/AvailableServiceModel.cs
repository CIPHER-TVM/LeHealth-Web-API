using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class AvailableServiceModel
    {
        public int GroupId { get; set; }
        public List<int> GroupIdList { get; set; }
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int SubId { get; set; }
        public String SubType { get; set; }
        public String OrderNo { get; set; }
        public String OrderDate { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }
        public int ConsultationId { get; set; }
        public int PackId { get; set; }
        public String PackNo { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public String ConsultDate { get; set; }
        public int ItemId { get; set; }
        public String ItemCode { get; set; }
        public String ItemName { get; set; }
        public int ValidityDays { get; set; }
        public int ValidityVisits { get; set; }
        public int AllowRateEdit { get; set; }
        public int AllowDisc { get; set; }
        public int AllowPP { get; set; }
        public int IsVSign { get; set; }
        public int ResultOn { get; set; }
        public int STypeId { get; set; }
        public int TotalTaxPcnt { get; set; }
        public int AllowCommission { get; set; }
        public int CommPcnt { get; set; }
        public int CommAmt { get; set; }
        public int MaterialCost { get; set; }
        public int BaseCost { get; set; }
        public int HeadId { get; set; }
        public int SortOrder { get; set; }
        public int IsDeleted { get; set; }
        public String BlockReason { get; set; }
        public int CPTCodeId { get; set; }
        public int? ExternalItem { get; set; }
        public int? RGroupId { get; set; }
        public int Rate { get; set; }
        public String GroupName { get; set; }
        public String GroupCode { get; set; }
        public int GroupCommPcnt { get; set; }
        public String Category { get; set; }
        public int GroupType { get; set; }
        public String ItemStatus { get; set; }
        public String Status { get; set; }
        public String PayStatus { get; set; }
        public String PatientName { get; set; } 
        public int LocationId { get; set; }
        public int SerialNo { get; set; } 
        public int OrderDetId { get; set; }  
        public String CancelReason { get; set; }  
        public String OrderFromDate { get; set; }  
        public String OrderToDate { get; set; }   
        public String ConsultantName { get; set; }   
        public String FirstName { get; set; }   
        public String MiddleName { get; set; }   
        public String LastName { get; set; }   
        public String RegNo { get; set; }   
        public String Mobile { get; set; }   
        public String ResNo { get; set; }    
        public Int32 Selected { get; set; }    
        public Int32 IsExternalConsultant { get; set; }    
        public Int32 IsCancelled { get; set; }    
        public Int32 DrugTypeId { get; set; }    
        public Int32 VaccineTypeId { get; set; }    
        public string DefaultTAT { get; set; }    
        public List<ItemDataModel> ItemObj { get; set; }
    }
    public class ItemDataModel
    {
        public Int32 ItemId { get; set; } 
        public Int32 ItemType { get; set; } 
        public Int32 itemTypeId { get; set; } 
        
    }
    public class ItemRateModel
    {
        public int ItemId { get; set; }
        public int RGroupId { get; set; }
        public string RGroupName { get; set; }
        public float Rate { get; set; }
    }

    public class ItemTaxModel
    {
        public int ItemId { get; set; }
        public int TaxId { get; set; }
        public string TaxName { get; set; }
        public float TaxPercent { get; set; }
        public int IsTaxApplicable { get; set; } 
    }
    public class ServiceConfigModel
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
        public int TotalTaxPcnt { get; set; }
        public bool AllowCommission { get; set; }
        public int CommPcnt { get; set; }
        public int CommAmt { get; set; }
        public int MaterialCost { get; set; }
        public int BaseCost { get; set; }
        public int HeadId { get; set; }
        public int SortOrder { get; set; }
        public int IsDeleted { get; set; }
        public string BlockReason { get; set; }
        public int CPTCodeId { get; set; }
        public bool ExternalItem { get; set; }
        public string GroupName { get; set; }
        public string GroupCode { get; set; }
        public int GroupCommPcnt { get; set; }
        public string Category { get; set; }
        public int GroupType { get; set; }
        public int DrugTypeId { get; set; }
        public int VaccineTypeId { get; set; }
        public string DefaultTAT { get; set; }
        public bool StaffMandatory { get; set; }//NEW FIELD
        public int ContainerId { get; set; } //NEW FIELD 
    }
}
