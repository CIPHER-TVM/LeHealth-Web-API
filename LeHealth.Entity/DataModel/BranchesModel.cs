using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class HospitalRequestModel
    {
        public String HospitalJson { get; set; }
        public IFormFile Logo { get; set; }
        public IFormFile ReportLogo { get; set; }
    }
    public class HospitalRegModel : HospitalModel
    {

        public IFormFile LogoFile { get; set; }
        public IFormFile ReportLogoFile { get; set; }
    }
    public class HospitalModel
    {
        public Int32 HospitalId { get; set; }
        public String HospitalName { get; set; }
        public String HospitalCode { get; set; }
        public String Caption { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Street { get; set; }
        public String PlacePO { get; set; }
        public String PIN { get; set; }
        public String City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public String Phone { get; set; }
        public String Fax { get; set; }
        public String Email { get; set; }
        public String URL { get; set; }
        public String Logo { get; set; }
        public String ReportLogo { get; set; }
        public String ClinicId { get; set; }
        public String DHAFacilityId { get; set; }
        public String DHAUserName { get; set; }
        public String DHAPassword { get; set; }
        public String SR_ID { get; set; }
        public String MalaffiSystemcode { get; set; }
        public int UserId { get; set; }
        public int Active { get; set; } 
        public String BlockReason { get; set; }  
    }
}
