﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int GroupId { get; set; }
        public int ValidityDays { get; set; }
        public int ValidityVisits { get; set; }
        public int AllowrateEdit { get; set; }
        public int AllowDisc { get; set; }
        public int AllowPP { get; set; }
        public int IsVSign { get; set; }
        public int ResultOn { get; set; }
        public int STypeId { get; set; }
        public float TotalTaxPcnt { get; set; }
        public int AllowCommission { get; set; }
        public int CommPcnt { get; set; }
        public int CommAmt { get; set; }
        public int MaterialCost { get; set; }
        public int BaseCost { get; set; }
        public int HeadId { get; set; }
        public int SortOrder { get; set; }
        public int CPTCodeId { get; set; }
        public int ExternalItem { get; set; }
    }
    public class ItemModelAll : ItemModel
    {
        public int BranchId { get; set; }
    }
}