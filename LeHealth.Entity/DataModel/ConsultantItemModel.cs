using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantItemModel
    {
        public int ConsultantId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int GroupId { get; set; }
        public int SessionId { get; set; }
        public string GroupName { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int ItemSelect { get; set; }
    }
}
