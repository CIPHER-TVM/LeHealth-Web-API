using System;
using System.Collections.Generic;
using System.Text;

namespace LeHealth.Entity.DataModel
{
    public class RateGroupModel
    {
        public int RGroupId { get; set; }
        public string RGroupName { get; set; }
        public string Description { get; set; }
        public string EffectFrom { get; set; }
        public string EffectTo { get; set; }
        public int UserId { get; set; }
        public int BranchId { get; set; }
        public int IsDisplayed { get; set; }
        public bool IsStandard { get; set; }
        public List<ItemRateDetailModel> Rate { get; set; }
        public List<ItemRateInputModel> BaseCostData { get; set; }
    }
    public class RateGroupModelAll : RateGroupModel
    {
        public int ShowAll { get; set; }
    }
    public class ItemRateInputModel
    {
        public int ItemId { get; set; }
        public float BaseCost { get; set; }
    }
}
