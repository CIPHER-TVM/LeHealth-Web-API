using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class BodyPartRequestModel
    {
        public string BodyPartJson { get; set; }
        public IFormFile BodyPartImg { get; set; }
    }
    public class BodyPartRegModel : BodyPartModel
    {
        public IFormFile BodyPartImgFile { get; set; }
    }
    public class BodyPartModel
    {
        public int BodyId { get; set; }
        public string BodyDesc { get; set; }
        public string BodyPartImageLocation { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }

    }
    public class BodyPartModelReturn
    {
        public int BodyId { get; set; }
        public string BodyDesc { get; set; }
        public string BodyPartImageLocation { get; set; }
        public string BodyPartFileName { get; set; }
        public int IsDisplayed { get; set; }
    }
}
