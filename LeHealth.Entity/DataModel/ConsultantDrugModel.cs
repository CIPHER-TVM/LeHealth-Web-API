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
        public string DDCCode { get; set; }
        public string DrugCode { get; set; }
        public int DosageId { get; set; }
        public string Dosage { get; set; }
        public string DosageForm { get; set; }
        public string FormDatas { get; set; }
        public int RouteId { get; set; }
        public string RouteDesc { get; set; }
        public int FreqId { get; set; }
        public string FreqDesc { get; set; }
        public int FreqMode { get; set; }
        public string Duration { get; set; }
        public string DurationMode { get; set; }
        public string ScientificName { get; set; }
        public int ScientificNameId { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int IsDisplayed { get; set; }
        public int Qty { get; set; }
        public int IsUpdate { get; set; } 
        public string Instruction { get; set; }
    }
}
