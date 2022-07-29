using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ConsultantReductionModel
    {
        public int ConsultantId { get; set; }
        public int SponsorId { get; set; }
        public int ItemGroupId { get; set; }
        public float DiscPerc { get; set; }
        public string ItemGroupName { get; set; }
        public List<ConsultantReductionListModel> ConsultantReductionList { get; set; }
    }
    public class ConsultantReductionListModel
    {
        public int ItemGroupId { get; set; }
        public float DiscPerc { get; set; }
    }
}
