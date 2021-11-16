using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultationByPatientIdModel
    {
        public int ItemId { get; set; }
        public String ItemName { get; set; }
        public String ConsultDate { get; set; }
        public int SeqNo { get; set; }
        public int ConsultFee { get; set; }
        public String ExpiryDate { get; set; }
        public int RemainVisits { get; set; }
        public String Symptoms { get; set; }
        public int ConsultType { get; set; }
        public int Emergency { get; set; }
        public int ExpiryVisits { get; set; }
        public bool IsConsultationExpired { get; set; }
    }
}
