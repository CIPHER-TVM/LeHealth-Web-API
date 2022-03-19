using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantDiseaseModel
    {
        public int DiseaseId { get; set; }
        public int DiseaseDesc { get; set; }
        public int ConsultantId { get; set; }
        public int LabelId { get; set; }
        public int SymptomId { get; set; }
        public int Since { get; set; }
        public int Duration { get; set; }
        public int Active { get; set; }
        public string BlockReason { get; set; }
    }
}
