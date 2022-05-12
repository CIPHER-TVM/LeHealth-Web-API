using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class HospitalRequestModel
    {
        public string HospitalJson { get; set; }
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
        public string HospitalName { get; set; }
        public string HospitalCode { get; set; }
        public string Caption { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string PlacePO { get; set; }
        public string PIN { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
        public string Logo { get; set; }
        public string ReportLogo { get; set; }
        public string ClinicId { get; set; }
        public string DHAFacilityId { get; set; }
        public string DHAUserName { get; set; }
        public string DHAPassword { get; set; }
        public string SR_ID { get; set; }
        public string MalaffiSystemcode { get; set; }
        public int UserId { get; set; }
    }
}
