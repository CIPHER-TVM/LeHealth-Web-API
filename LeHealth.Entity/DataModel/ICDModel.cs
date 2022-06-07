using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ICDModel
    {
        public int LabelId { get; set; }
        public string LabelDesc { get; set; }
        public string LabelCode { get; set; }
    }

    //public class ICDCategroyModel
    //{
    //    public int CatgId { get; set; }
    //    public string CatgDesc { get; set; }

    //}
    public class ICDGroupModel
    {
        public int GroupId { get; set; }
        public string GroupDesc { get; set; }
        public string GroupRange { get; set; }
        public int IsDisplayed { get; set; }
    }
    public class ICDGroupModelAll : ICDGroupModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; }
        public int ShowAll { get; set; }
    }
    public class ICDLabelModel
    {
        public int LabelId { get; set; }
        public string LabelDesc { get; set; }
        public string LabelCode { get; set; }
        public int GroupId { get; set; }
        public string GroupDesc { get; set; }
        public int CatgId { get; set; }
        public string CatgDesc { get; set; }
        public int IsDisplayed { get; set; }
        public List<LabelSign> LabelSigns { get; set; }
        public List<LabelSymptom> LabelSymptoms { get; set; }
    }
    public class ICDLabelModelAll : ICDLabelModel
    {
        public int BranchId { get; set; }
        public int UserId { get; set; } 
        public int ShowAll { get; set; }
    }
    public class LabelSign
    {
        public int SignId { get; set; }
        public string SignDesc { get; set; } 
    }
    public class LabelSymptom
    {
        public int SymptomId { get; set; }
        public string SymptomDesc { get; set; } 
    }

}
