using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantMasterModel
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public int ConsultantId { get; set; }
        public string SpecialityCode { get; set; }
        public string ConsultantCode { get; set; }
        public int DeptId { get; set; }
        public string Designation { get; set; }
        public string CRegNo { get; set; }
        public string DOJ { get; set; }
        public string DateOfJoin { get; set; }
        public string Specialisation { get; set; }
        public string RoomNo { get; set; }
        public int SortOrder { get; set; }



        public int NationalityId { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public int Month { get; set; }
        public string Qualification { get; set; }
        //public ConsultantAddressModel Residence { get; set; }
        public string Mobile { get; set; }
        public string ResPhone { get; set; }
        public string OffPhone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int TimeSlice { get; set; }
        public int MaxPatients { get; set; }
        public int ConsultantLedger { get; set; }
        public int CommissionId { get; set; }
        public bool AllowCommission { get; set; }
        public bool AllowConsultantLogin { get; set; }
        public bool DeptOverrule { get; set; }
        public bool DeptWiseConsultation { get; set; }
        public bool ExternalConsultant { get; set; }
        public bool ConsultantMedicationReport { get; set; }
        public int AppType { get; set; }
        public string BlockReason { get; set; }
        public int ItemId { get; set; }
        public int UserId { get; set; }
        //public byte[] Signature { get; set; }
        public int DrugRefType { get; set; } 
        public string SignatureLoc { get; set; }
        public string Location { get; set; }
        public List<LocationModel> LocationIds { get; set; }
        public int BranchId { get; set; }
        public int IsDeleted { get; set; }
        public int IsDisplayed { get; set; }
        public UserModel UserData { get; set; }
        public int ShowAll { get; set; }
        public List<ItemIdListCls> ItemIdList { get; set; }

        //Address Data Start
        public int AddType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PlacePO { get; set; }
        public string PIN { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryId { get; set; }
        //Address Data End
    }
    public class ItemIdListCls
    {
        public int itemId { get; set; } 
        public string itemName { get; set; }   
    }
    public class UserSettingsModel
    {
        public int ConsultantId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int BranchId { get; set; }
        public int GroupId { get; set; }
    }
    public class ConsultantRequestModel
    {
        public string ConsultantJson { get; set; }
        public IFormFile SignaturePhoto { get; set; }
    }
    public class ConsultantRegModel : ConsultantMasterModel
    {

        public IFormFile PhotoFile { get; set; }

    }
}
