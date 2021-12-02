using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RegAddressModel
    {
        public int PatientId { get; set; }
        public int AddType { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Street { get; set; }
        public String PlacePO { get; set; }
        public String PIN { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int CountryId { get; set; }
    }
}
