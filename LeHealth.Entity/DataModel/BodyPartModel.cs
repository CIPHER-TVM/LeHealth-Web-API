using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class BodyPartModel
    {
        public int BodyId { get; set; } 
        public String BodyDesc { get; set; } 
        public int UserId { get; set; }  
        public int Active { get; set; }  
        public String BlockReason { get; set; }   
    }
}
