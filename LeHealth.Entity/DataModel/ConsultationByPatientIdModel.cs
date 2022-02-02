using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultationByPatientIdModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ConsultDate { get; set; }
        public int SeqNo { get; set; }
        public int ConsultFee { get; set; }
        public string ExpiryDate { get; set; }
        public int RemainVisits { get; set; }
        public string Symptoms { get; set; }
        public int ConsultType { get; set; }
        public int Emergency { get; set; }
        public int ExpiryVisits { get; set; }
        public bool IsConsultationExpired { get; set; }
    }
}
