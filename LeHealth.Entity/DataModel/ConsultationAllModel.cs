using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    class ConsultationAllModel
    {
        public String TokenNO { get; set; }
        public String PatientName { get; set; }
        public int? TimeNo { get; set; }
        public String RegNo { get; set; }
        public String Sponsor { get; set; }
        public int? ConsultationId { get; set; }
        public int? AppId { get; set; }
        public String ConsultDate { get; set; }
        public int? ConsultantId { get; set; }
        public int? PatientId { get; set; }
        public String Symptoms { get; set; }
        public int? ConsultType { get; set; }
        public float ConsultFee { get; set; }
    }
}
