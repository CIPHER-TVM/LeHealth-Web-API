using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class GroupModel
    {
        public int GroupId { get; set; }
        public String GroupName { get; set; }
        public String GroupCode { get; set; }
    }
    public class GroupModelAll : GroupModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
