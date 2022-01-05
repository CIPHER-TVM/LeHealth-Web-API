using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsentFormSaveRequestModel
    {
        public string ConsentJson { get; set; }
        public IFormFile Sign { get; set; }
    }
    public class ConsentFormRegModel : ConsentFormDataSaveModel
    {
        public IFormFile SignFile { get; set; }
    }
    public class ConsentFormDataSaveModel
    {
        public Int32 ConsentId { get; set; }
        public Int32 PatientId { get; set; }
        public Int32 BranchId { get; set; }
        public string Sign { get; set; } 
    }
}
