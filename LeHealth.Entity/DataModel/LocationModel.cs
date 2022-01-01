using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Supervisor { get; set; }
        public string ContactNumber { get; set; }
        public int LTypeId { get; set; }
        public int ManageSPoints { get; set; }
        public int ManageBilling { get; set; }
        public int ManageCash { get; set; }
        public int ManageCredit { get; set; }
        public int ManageIPCredit { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
        public string RepHeadImg { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int UserId { get; set; }
    }
}
