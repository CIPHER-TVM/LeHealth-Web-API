using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class SponsorFormModel
    {
        public List<SponsorRuleGroupModel> SponsorRuleGroupList { get; set; }
        public int SFormId { get; set; }
        public string SFormName { get; set; }
        public int IsDisplayed { get; set; }
        public int IsDeleted { get; set; }
        public string BlockReason { get; set; }

    }
}
