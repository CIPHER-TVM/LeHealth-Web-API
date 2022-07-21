using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientQuestionareModel: QuestionModel
    {
        public int PatientId { get; set; }
        public int AnsId { get; set; }
        public string Notes { get; set; }
    }

    public class QuestionModel
    {
        public int QnId { get; set; }
        public string Question { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; } 
        public bool IsDisplayed { get; set; } 
        public int IsDeleting { get; set; }   
        public int ShowAll { get; set; }    
        public int SortOrder { get; set; }    
    }
    public class PatientQuestionareModelInput
    {
        public List<PatientQuestionareModel> PatientQuestionares { get; set; }
    }
}
