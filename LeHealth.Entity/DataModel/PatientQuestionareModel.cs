using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientQuestionareModel
    {
        public int PatientId { get; set; }
        public int QnId { get; set; }
        public string Question { get; set; }
        public int AnsId { get; set; }
        public int BranchId { get; set; }
    }
    public class PatientQuestionareModelInput
    {
        public List<PatientQuestionareModel> PatientQuestionares { get; set; }
    }
}
