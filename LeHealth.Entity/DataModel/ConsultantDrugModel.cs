using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantDrugModel
    {
        public int ConsultantId { get; set; }
        public int DrugTypeId { get; set; }
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public int DosageId { get; set; }
        public string Dosage { get; set; }
        public int RouteId { get; set; }
        public string RouteDesc { get; set; }
        public int FreqId { get; set; }
        public string FreqDesc { get; set; }
        public int Duration { get; set; }
        public string DurationMode { get; set; }
        public int UserId { get; set; }
      

    }
}
