using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class VisaTypeModel
    {
        public int VisaTypeID { get; set; }
        public string VisaType { get; set; }
    }
    public class VisaTypeModelAll : VisaTypeModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
