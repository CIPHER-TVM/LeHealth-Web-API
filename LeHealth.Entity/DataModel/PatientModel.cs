﻿using Microsoft.AspNetCore.Http;
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
    public class PatientRegModel: PatientModel
    {
       
        public List<IFormFile> PatientDocs { get; set; }
        public IFormFile PatientPhoto { get; set; }
    }
    public class PatientModel
    {
        public ConsultationModel Consultation { get; set; }
        public List<RegAddressModel> RegAddress { get; set; }
        public List<RegIdentitiesModel> RegIdentities { get; set; }
        public List<RegDetModel> RegDet { get; set; }
        public List<RegDocLocationModel> RegDocLocation { get; set; } 
       
        public List<string> PatientDocNames { get; set; }
        public string PatientPhotoName { get; set; }

        public int PatientId { get; set; }
        public int RegId { get; set; }
        public string RegNo { get; set; }
        public string RegDate { get; set; }
        public int RegAmount { get; set; }
        public int ItemId { get; set; }
        public string ExpiryDate { get; set; }
        public int AddType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PlacePO { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PIN { get; set; }
        public int CountryId { get; set; }
        public int Salutation { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int IdentityType { get; set; }
        public int IdentityNo { get; set; }
        public int Gender { get; set; }
        public string DOB { get; set; }
        public int MaritalStatus { get; set; }
        public string KinName { get; set; }
        public string KinDOB { get; set; }
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
        public int NationalityId { get; set; }
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
        public int RetVal { get; set; }
        public string RetDesc { get; set; }
        public string RetRegNo { get; set; }
        public string Hook { get; set; }
        public string SchemeName { get; set; } 

        //

        public string RegFromDate { get; set; }
        public string RegToDate { get; set; }
        public string PolicyNo { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Consultant { get; set; }
        public string Telephone { get; set; }
        public string SponsorName { get; set; }
        public string SponsorId { get; set; }
        public string EnableSponsorConsent { get; set; }
        public string EmirateID { get; set; }
        public string CompanyName { get; set; } 
        public string BlockReason { get; set; } 
        public int CommunicationType { get; set; }  
    }
}
