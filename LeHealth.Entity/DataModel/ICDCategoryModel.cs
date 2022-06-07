using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ICDCategoryModel
    {
        public int CatgId { get; set; }
        public string CatgName { get; set; }
        public string CatgDesc { get; set; }
        public int ICDGroupId { get; set; }
        public bool IsDisplayed { get; set; }
    }
    public class ICDCategoryModelAll : ICDCategoryModel
    {
        public int ShowAll { get; set; }
        public int BranchId { get; set; }
        public int UserId { get; set; } 
    }
}
