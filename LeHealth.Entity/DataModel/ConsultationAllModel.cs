using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    class ConsultationAllModel
    {
        public string TokenNO { get; set; }
        public string PatientName { get; set; }
        public int? TimeNo { get; set; }
        public string RegNo { get; set; }
        public string Sponsor { get; set; }
        public int? ConsultationId { get; set; }
        public int? AppId { get; set; }
        public string ConsultDate { get; set; }
        public int? ConsultantId { get; set; }
        public int? PatientId { get; set; }
        public string Symptoms { get; set; }
        public int? ConsultType { get; set; }
        public float ConsultFee { get; set; }
    }
}
