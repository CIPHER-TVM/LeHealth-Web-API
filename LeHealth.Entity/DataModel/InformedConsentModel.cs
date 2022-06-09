using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class InformedConsentModel
    {
        public int ContentId { get; set; }
        public string CTEnglish { get; set; }
        public string CTArabic { get; set; }
        public int DisplayOrder { get; set; }
        public string CType { get; set; }
        public int CGroupId { get; set; }
        public string CGroupName { get; set; }
        public int Active { get; set; }
        public int IsDeleted { get; set; }
        public string BlockReason { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class InformedConsentModelAll : InformedConsentModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
       
    }
}
