using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class NationalityGroupModel
    {
        public int NGroupId { get; set; }
        public string NGroupDesc { get; set; }
        public string RegionCode { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class NationalityGroupModelAll : NationalityGroupModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
    }
}
