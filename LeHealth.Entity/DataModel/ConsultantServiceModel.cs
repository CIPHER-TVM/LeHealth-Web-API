using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantServiceModel
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ConsultantId { get; set; }
        public List<int> ItemIdList { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
    }

}
