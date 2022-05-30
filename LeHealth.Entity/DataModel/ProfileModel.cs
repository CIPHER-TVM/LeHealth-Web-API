using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ProfileModel
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public string ProfileDesc { get; set; }
        public string Remarks { get; set; }
        public bool Active { get; set; }
        public string BlockReason { get; set; } 
        public List<int> ProfileIds { get; set; }
        public List<ProfileItemModel> ProfileItems { get; set; }
    }
    public class ProfileItemModel
    {
        public int ProfileId { get; set; }
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public double Rate { get; set; }
    }
    
}
