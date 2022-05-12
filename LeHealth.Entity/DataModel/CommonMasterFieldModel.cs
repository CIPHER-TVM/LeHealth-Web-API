using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class CommonMasterFieldModel
    {
        public int Id { get; set; }
        public string NameData { get; set; }
        public string CodeData { get; set; }
        public string DescriptionData { get; set; }
        public int MasterFieldType { get; set; } 
    }
    public class CommonMasterFieldModelAll : CommonMasterFieldModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
        public int IsDisplayed { get; set; }
    }
}
