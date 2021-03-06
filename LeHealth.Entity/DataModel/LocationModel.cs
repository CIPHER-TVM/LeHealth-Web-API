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
        public string LType { get; set; }
        public bool ManageSPoints { get; set; }
        public bool ManageBilling { get; set; }
        public bool ManageCash { get; set; }
        public bool ManageCredit { get; set; }
        public bool ManageIPCredit { get; set; }
        public string RepHeadImg { get; set; }
        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public int UserId { get; set; }
        public string BlockReason { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class LocationType
    {
        public int LTypeId { get; set; }
        public string LTypeName { get; set; }
    }
    public class LocationAll : LocationModel
    {
        public int ShowAll { get; set; }        
    }
public class LocationAssociateModel
    {
        public int LocationId { get; set; }
        public List<LocationModel> AssociateLcations { get; set; }
        // public int AstLocationId { get; set; }
    }


}
