using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
   public class PatientBillModel
    {
        public string PatientName { get; set; }
        public string DeptName { get; set; }
        public string RegNo { get; set; }
        public string ConsultDate { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }
        public int BranchId { get; set; }
        public int ConsultationId { get; set; }
        public int Sponsorid { get; set; }
        public int DeptId { get; set; }
        public string Billdate { get; set; }
        public string Billstatus { get; set; }
        public string PayStatus { get; set; }
        public string status { get; set; }
        public string ConsultantName { get; set; }
        public string Sponsor { get; set; }
       
    }
}
