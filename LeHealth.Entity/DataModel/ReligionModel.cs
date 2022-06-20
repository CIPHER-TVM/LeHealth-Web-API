using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ReligionModel
    {
        public int Id { get; set; }
        public string ReligionName { get; set; }
        public string ReligionCode { get; set; }
    }
    public class ReligionModelAll : ReligionModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
