using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class PatientConsentModel
    {
        public int ContentId { get; set; }
        public string CTEnglish { get; set; }
        public string CTArabic { get; set; }
        public int DisplayOrder { get; set; }
        public string CType { get; set; }
        public int CGroupId { get; set; }
        public int Active { get; set; }
        public int IsDeleted { get; set; }
        public string BlockReason { get; set; }
    }
    public class PatientConsentModelAll : PatientConsentModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
