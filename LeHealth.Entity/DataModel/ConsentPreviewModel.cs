using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsentPreviewModel
    {
        public List<ConsentContentModel> ConsentContentValue { get; set; }
        public String PatientName { get; set; } 
        public String FileLoc { get; set; } 
        public int PatientId { get; set; }  
    } 
}
