using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ZoneModel
    {
        public int Id { get; set; }
        public string ZoneName { get; set; }
        public int IsActive { get; set; } 
        public int OperatorId { get; set; }  
        public int ZoneCountry { get; set; }   
        public string ZoneCode { get; set; }   
        public string ZoneDescription { get; set; }    
    }
}
