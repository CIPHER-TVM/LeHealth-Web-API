using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class DiseaseModel
    {
        public int DiseaseId { get; set; }
        public string DiseaseDesc { get; set; }
        public int ConsultantId { get; set; }
        public int LabelId { get; set; }
        public List<DiseaseSymptomModel> Symptoms { get; set; }
        public List<DiseaseSignModel> Signs { get; set; }
        public DiseaseICDModel ICD { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
        public int BranchId { get; set; }
    }
    public class DiseaseSymptomModel
    {
        public int DiseaseId { get; set; }
        public int SymptomId { get; set; }
        public string SymptomDesc { get; set; }
        public int Since { get; set; }
        public string Duration { get; set; }
        public string Selected { get; set; }
    }
    public class DiseaseSignModel
    {
        public int DiseaseId { get; set; }
        public int SignId { get; set; }
        public string SignDesc { get; set; }
        public int Since { get; set; }
        public string Duration { get; set; }
        public string Selected { get; set; }
    }

    public class DiseaseICDModel
    {
        public int LabelId { get; set; }
        public int DiseaseId { get; set; }
        public string LabelDesc { get; set; }
        public string LabelCode { get; set; }
        public string Selected { get; set; } = "true";
    }

}
