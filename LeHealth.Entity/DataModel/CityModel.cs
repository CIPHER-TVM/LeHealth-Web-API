using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CityModel
    {
        public int CityId { get; set; }
        public String CityName { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public String CountryName { get; set; } 
        public int UserId { get; set; } 
    }
}
