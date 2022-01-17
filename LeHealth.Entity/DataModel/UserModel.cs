using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool Active { get; set; }
        public string BlockReason { get; set; }
        public string Branches { get; set; }
        public List<string> BranchIds { get; set; }
    }
}
