using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ZoneModel
    {
        public int Id { get; set; }
        public string ZoneName { get; set; }
        public int OperatorId { get; set; }
        public int ZoneCountry { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneDescription { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class ZoneModelAll : ZoneModel
    {
        public int IsDeleting { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
    }
}
