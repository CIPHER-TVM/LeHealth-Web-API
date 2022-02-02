using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientRequestModel
    {
        public string PatientJson { get; set; }
        public List<IFormFile> PatientDocs { get; set; }
        public IFormFile PatientPhoto { get; set; }
    }
    public class PatientRegModel : PatientModel
    {

        public List<IFormFile> PatientDocs { get; set; }
        public IFormFile PatientPhoto { get; set; }
    }
    public class PatientModel
    {
        public ConsultationModel Consultation { get; set; }
        public List<RegAddressModel> RegAddress { get; set; }
        public List<RegIdentitiesModel> RegIdentities { get; set; }
        public List<RegSymptomsModel> Symptoms { get; set; }  
        public List<RegDocLocationModel> RegDocLocation { get; set; }
        public List<String> PatientDocNames { get; set; }
        public string PatientPhotoName { get; set; }
        public int PatientId { get; set; }
        public string RegNo { get; set; }
        public int IsManualRegNo { get; set; } 
        public string RegDate { get; set; }
        public int ItemId { get; set; }
        public int Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PatientName { get; set; }
        public int Gender { get; set; }
        public string DOB { get; set; }
        public int MaritalStatus { get; set; }
        public string KinName { get; set; }
        public int KinRelation { get; set; }
        public string KinContactNo { get; set; }
        public string Mobile { get; set; }
        public string ResNo { get; set; }
        public string OffNo { get; set; }
        public string Email { get; set; }
        public string FaxNo { get; set; }
        public int Religion { get; set; }
        public int CmpId { get; set; }
        public int Status { get; set; } 
        public int PatState { get; set; }
        public int ProfId { get; set; }
        public int RGroupId { get; set; }
        public string Mode { get; set; }
        public string Remarks { get; set; }
        public string OtherReasons { get; set; }
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }  
        public int ConsultantId { get; set; }
        public int Active { get; set; }
        public int AppId { get; set; }
        public string RefBy { get; set; }
        public bool PrivilegeCard { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public string WorkEnvironMent { get; set; }
        public string ProfessionalNoxious { get; set; }
        public string ProfessionalExperience { get; set; }
        public int VisaTypeId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public string RetRegNo { get; set; }
        public string Hook { get; set; }
        public string SchemeName { get; set; }
        public string BlockReason { get; set; }
        public int CommunicationType { get; set; }
        public int AgeInMonth { get; set; }
        public int AgeInYear { get; set; } 
        //
        public string RGroupName { get; set; } 
        public string ItemName { get; set; } 
        public string CountryName { get; set; } 
        public string MaritalStatusDescription { get; set; } 
        public string GenderName { get; set; } 
        public string VisaType { get; set; } 
        public string ProfName { get; set; } 
        public string CmpName { get; set; }  
        public int DepartmentId { get; set; }  
        public int? ConsultationId { get; set; }
        public string DepartmentName { get; set; }
        public string ConsultantName { get; set; }
        public string ErrorMessage { get; set; }  
    }
}
