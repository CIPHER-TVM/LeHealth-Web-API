using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; } 
        public string Country { get; set; }  
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
        public int BranchId { get; set; } 
    }
}
