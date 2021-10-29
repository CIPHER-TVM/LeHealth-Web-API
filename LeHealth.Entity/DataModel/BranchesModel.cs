using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
  
    public class HospitalModel
    {
        public Int32 HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string HospitalCode { get; set; }

        public string PlacePO { get; set; }
    }

}
