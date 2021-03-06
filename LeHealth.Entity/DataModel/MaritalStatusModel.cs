using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class MaritalStatusModel
    {
        public int Id { get; set; }
        public string MaritalStatusDescription { get; set; }
    }
    public class MaritalStatusModelAll : MaritalStatusModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
