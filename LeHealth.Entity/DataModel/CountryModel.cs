using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CountryModel
    {
        public string CountryName { get; set; }
        public string NationalityName { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string ReportCode { get; set; } 
        public int NGroupId { get; set; }
        public string NGroupDesc { get; set; }
        public int ShowAll { get; set; }
        public int BranchId { get; set; } 
        public int UserId { get; set; } 
        public int IsDisplayed { get; set; }  

    }
}
