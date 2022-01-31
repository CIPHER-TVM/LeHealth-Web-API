using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class ConsentContentModel
    {
        public int ContentId { get; set; }
        public String CTEnglish { get; set; }
        public String CTArabic { get; set; } 
        public int DisplayOrder { get; set; } 
        public int CType { get; set; } 
        public int CGroupId { get; set; }  
        public int Active { get; set; }   
        public int SponsorId { get; set; }    
        public String BlockReason { get; set; }     
    }
}
