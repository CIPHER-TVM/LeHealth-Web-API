using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{

    public class CheckConsultantScheduleModel
    {
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }
        public string Date { get; set; }
        public List<int> SliceNo { get; set; }
    }
}
