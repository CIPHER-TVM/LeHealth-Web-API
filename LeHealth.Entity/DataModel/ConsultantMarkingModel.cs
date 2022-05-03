using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantMarkingRequestModel
    {
        public string ConsultantMarkingJson { get; set; }
        public IFormFile ConsultantMarkingImg { get; set; }
    }
    public class ConsultantMarkingRegModel : ConsultantMarkingModel
    {
        public IFormFile ConsultantMarkingFile { get; set; }
    }
    public class ConsultantMarkingModel
    {
        public int MarkId { get; set; }
        public string MarkDesc { get; set; }
        public int IndicatorId { get; set; }
        public string IndicatorDesc { get; set; }
        public string Colour { get; set; }
        public bool ShowCaption { get; set; }
        public int ConsultantId { get; set; } 
        public string ConsultantMarkingImageLocation { get; set; }
        public int BodyPartId { get; set; }
        public string BodyPartLocation { get; set; }
        public int BranchId { get; set; }
        public string Base64Img { get; set; } 
    }


}
