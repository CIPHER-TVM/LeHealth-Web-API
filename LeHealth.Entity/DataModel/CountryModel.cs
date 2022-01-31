using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CountryModel
    {
        public String CountryName { get; set; }
        public String NationalityName { get; set; }
        public int CountryId { get; set; }
        public String CountryCode { get; set; }
        public int NGroupId { get; set; }
        public int Active { get; set; }
        public String BlockReason { get; set; } 
        public int UserId { get; set; } 

    }
}
