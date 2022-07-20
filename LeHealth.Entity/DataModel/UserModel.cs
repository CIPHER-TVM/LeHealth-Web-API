using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class UserModel
    {
        public int P_UserId { get; set; } 
        public int UserId { get; set; }//Same As P_UserId
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; } 
        public bool Active { get; set; }
        public string BlockReason { get; set; }
        public string Branches { get; set; }
        public string BrancheIdstr { get; set; } 
        public List<string> BranchIds { get; set; }
        public string Groups { get; set; }
        public List<string> GroupIds { get; set; }
        public List<LocationModel> LocationIds { get; set; }
    }
    public class MapLocationModel
    {
        public int UserId { get; set; }
        public int Branch { get; set; }
        public List<string> LocationIds { get; set; }
        public string Locationstring { get; set; }
    }
    public class MapUserGroupModel
    {
        public int UserId { get; set; }
        public int Branch { get; set; }
        public int GroupId { get; set; }
        public string Groupstring { get; set; }
        public List<groupmap> Groups { get; set; }
    }
    public class groupmap
    {
        public int BranchId { get; set; }
        public int GroupId { get; set; }
    }
}
