using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
  
    public class ConsultantDrugsModel
    {
        public List<ConsultantDrugModel> DrugDetails { get; set; }
        public int ConsultantId { get; set; }
        public int UserId { get; set; }
        public int IsUpdate { get; set; }
    }
}
