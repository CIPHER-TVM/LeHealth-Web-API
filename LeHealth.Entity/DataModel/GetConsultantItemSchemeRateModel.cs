using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GetConsultantItemSchemeRateModel
    {
        public string ItemName { get; set; } 
        public int Rate { get; set; }  
        public int EmergencyFees { get; set; }   
    }
}
