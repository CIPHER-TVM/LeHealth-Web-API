using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SketchModel
    {
        public int Id { get; set; }
        public int ConsultantId { get; set; } 
        public string SketchName { get; set; }
        public string FileLocation { get; set; } 
    }
    public class SketchModelAll : SketchModel 
    {
        public string Base64Img { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
