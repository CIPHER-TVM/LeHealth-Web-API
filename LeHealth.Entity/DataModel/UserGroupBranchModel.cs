using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class Child
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
    }

    public class UserGroupBranchModel
    {
        public int BranchId { get; set; }
        public List<Child> Groups { get; set; }
    }
    //public class UserGroupBranchModel
    //{
    //public int BranchId { get; set; }
    //public string BranchName { get; set; }
    //public int GroupId { get; set; }
    //public string GroupName { get; set; }

    //public int BranchId { get; set; }
    //public int UserId { get; set; }
    //public int State { get; set; }
    //public bool Active { get; set; }
    //public String BlockReason { get; set; }
    //public String UserType { get; set; }
    //public String HospitalName { get; set; }
    //}
}
