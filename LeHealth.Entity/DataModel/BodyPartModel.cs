using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class BodyPartModel
    {
        public int BodyId { get; set; } 
        public string BodyDesc { get; set; } 
        public int UserId { get; set; }  
        public int Active { get; set; }  
        public string BlockReason { get; set; }   
    }
}
