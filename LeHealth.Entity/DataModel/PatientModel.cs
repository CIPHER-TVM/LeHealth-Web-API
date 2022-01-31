using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientRequestModel
    {
        public String PatientJson { get; set; }
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
        public String PatientPhotoName { get; set; }
        public int PatientId { get; set; }
        public String RegNo { get; set; }
        public int IsManualRegNo { get; set; } 
        public String RegDate { get; set; }
        public int ItemId { get; set; }
        public int Salutation { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String PatientName { get; set; }
        public int Gender { get; set; }
        public String DOB { get; set; }
        public int MaritalStatus { get; set; }
        public String KinName { get; set; }
        public int KinRelation { get; set; }
        public String KinContactNo { get; set; }
        public String Mobile { get; set; }
        public String ResNo { get; set; }
        public String OffNo { get; set; }
        public String Email { get; set; }
        public String FaxNo { get; set; }
        public int Religion { get; set; }
        public int CmpId { get; set; }
        public int Status { get; set; } 
        public int PatState { get; set; }
        public int ProfId { get; set; }
        public int RGroupId { get; set; }
        public String Mode { get; set; }
        public String Remarks { get; set; }
        public String OtherReasons { get; set; }
        public int NationalityId { get; set; }
        public String NationalityName { get; set; }  
        public int ConsultantId { get; set; }
        public int Active { get; set; }
        public int AppId { get; set; }
        public String RefBy { get; set; }
        public bool PrivilegeCard { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public String WorkEnvironMent { get; set; }
        public String ProfessionalNoxious { get; set; }
        public String ProfessionalExperience { get; set; }
        public int VisaTypeId { get; set; }
        public int SessionId { get; set; }
        public int BranchId { get; set; }
        public String RetRegNo { get; set; }
        public String Hook { get; set; }
        public String SchemeName { get; set; }
        public String BlockReason { get; set; }
        public int CommunicationType { get; set; }
        public int AgeInMonth { get; set; }
        public int AgeInYear { get; set; } 
        //
        public String RGroupName { get; set; } 
        public String ItemName { get; set; } 
        public String CountryName { get; set; } 
        public String MaritalStatusDescription { get; set; } 
        public String GenderName { get; set; } 
        public String VisaType { get; set; } 
        public String ProfName { get; set; } 
        public String CmpName { get; set; }  
        public int DepartmentId { get; set; }  
        public int? ConsultationId { get; set; }
        public String DepartmentName { get; set; }
        public String ConsultantName { get; set; }
        public String ErrorMessage { get; set; }  
    }
}
